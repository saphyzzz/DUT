using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    
    // Handle movement speed
    [Header("Movement")]
    private float moveSpeed;
    public float groundDrag; 
    Vector3 moveDirection; 
    public float walkSpeed; 
    public float sprintSpeed;

    // Handle states of movement 
    private MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        air
    }

    // Handle ground speed 
    [Header("Ground Check")]
    public float playerHeight; 
    public LayerMask whatIsGround; 
    bool grounded; 
    
    // Handle slopes 
    [Header("Slope Handling")]
    public float maxSlopeAngle; 
    private RaycastHit slopeHit; 
    public float airMultiplier;


    [Header("Keybinds")]
    public KeyCode sprintKey = KeyCode.LeftShift; 
    
    // Oritentation of player 
    public Transform orientation; 

    // Keyboard input for horizontal and vertical
    float horizontalInput; 
    float verticalInput; 

    // Handle States 
    public GameManager gameManager;  
    Rigidbody rb; 

    public void Start()
    {
        // Get rigid body 
        rb = GetComponent<Rigidbody>(); 
        rb.freezeRotation = true; 
    }

    public void Update()
    {

        // Check if the game is in Main Menu state
        if (gameManager.currentState ==  GameManager.GameState.MainMenu)
        {
            return; // Exit the method if in Main Menu state
        }

        // Check if ground is below player -> Raycast half the players height down, see if it hits ground 
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); 

        myInput(); 
        SpeedControl(); 
        StateHandler(); 

        // Handle drag 
        if(grounded)
        {
            rb.drag = groundDrag; 
        }
        else
        {
            rb.drag = 0; 
        }

    }

    private void FixedUpdate() 
    {
        // Check if the game is in Main Menu state
    if (gameManager.currentState == GameManager.GameState.MainMenu)
    {
        // Don't allow player movement in Main Menu
        return;  // Exit the method if in Main Menu state
    }
        MovePlayer();    
    }

    // Gets user input 
    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void StateHandler()
    {
        // Mode - Sprinting
        if(grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting; 
            moveSpeed = sprintSpeed; 
        }

        // Mode - Walking 
        else if(grounded)
        {
            state = MovementState.walking; 
            moveSpeed = walkSpeed; 
        }

        // Mode - Air 
        else
        {
            state = MovementState.air;

        }
    }

    // Handles movement of player 
    private void MovePlayer()
    {
        // Calculate movement direction - This way player will always walk in the direction they are looking in 
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; 
        rb.AddForce (moveDirection.normalized * moveSpeed * 10f, ForceMode.Force); 

        // Player on slope 
        if (OnSlope())
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0) // If player is moving upwards, add downwards force 
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        // On ground
        else if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // In air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        // Turn gravity off while on slope
        rb.useGravity = !OnSlope();
   }

    // Handle how fast a player can go
    private void SpeedControl()
    {
        // Limiting speed on slope 
        if(OnSlope())
        {
            if(rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed; 
            }
        }

        // Limiting speed on ground or in air 
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            /* Limit velocity if needed, if player goes faster than movement speed, calculate what the movement speed 
            would be then apply it */ 
            if(flatVel.magnitude > moveSpeed){
                Vector3 limitedVel = flatVel.normalized * moveSpeed; // Returns a new vector in the same direction as flatVel but with a length of 1, 
                                                                    // multipling by moveSpeed gets same speed of moveSpeed 
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); 
            }
        }
    }

    // Handle player on slopes 
    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f)) // slopeHit stores object that player has hit 
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal); 
            return angle < maxSlopeAngle && angle != 0; 
        }

        return false; 
    }

    // Projecting slopHit onto the slope below player 
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

}
