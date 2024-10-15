using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    
    // Handle movement speed
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag; 
    Vector3 moveDirection; 

    // Handle ground speed 
    [Header("Ground Check")]
    public float playerHeight; 
    public LayerMask whatIsGround; 
    bool grounded; 

    // Oritentation of player 
    public Transform orientation; 

    // Keyboard input for horizontal and vertical
    float horizontalInput; 
    float verticalInput; 

    // Handle States 
    public GameManager gameManager;  
    
    // Handles jumping of player 
    public float jumpForce; 
    public float jupmpCooldown; 
    public float airMultiplier; 
    bool readyToJump;   

    [Header("Keybinds")]
    public KeyCode jumpkey = KeyCode.Space; 
    Rigidbody rb; 

    public void Start()
    {
        // Get rigid body 
        rb = GetComponent<Rigidbody>(); 
        rb.freezeRotation = true; 
        readyToJump = true;
    }

    public void Update()
    {

        // Check if the game is in Main Menu state
        // if (gameManager.currentState == GameState.MainMenu)
        // {
        //     // Don't allow player movement in Main Menu
        //     return;
        // }
        // Check if ground is below player -> Raycast half the players height down, see if it hits ground 
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); 

        // Handle drag 
        if(grounded)
        {
            rb.drag = groundDrag; 
        }
        else
        {
            rb.drag = 0; 
        }

        // Check for new input each update 
        myInput(); 
        SpeedControl(); 
    }

    private void FixedUpdate() 
    {
        MovePlayer();    
    }

    // Gets user input 
    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // When player jumps 
        if(Input.GetKey(jumpkey) && readyToJump && grounded)
        {
            readyToJump = false; 

            Jump(); 
            Invoke(nameof(ResetJump), jupmpCooldown); 
        }
    }

    // Handles movement of player 
    private void MovePlayer()
    {
        // Calculate movement direction - This way player will always walk in the direction they are looking in 
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; 

        // On ground 
        if(grounded)
        {
            rb.AddForce (moveDirection.normalized * moveSpeed * 10f, ForceMode.Force); 
        }

        // In air 
        else if(!grounded) 
        {
            rb.AddForce (moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force); 
        }
    }

    // Handle how fast a player can go
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        /* Limit velocity if needed, if player goes faster than movement speed, calculate what the movement speed 
           would be then apply it */ 
        if(flatVel.magnitude > moveSpeed){
            Vector3 limitedVel = flatVel.normalized * moveSpeed; // Returns a new vector in the same direction as flatVel but with a length of 1, 
                                                                 // multipling by moveSpeed gets same speed of moveSpeed 
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.y); 
        }
    }

    // Handle jumping of a player 
    private void Jump()
    {
        // Reset the y velocity to allow same jump height each time 
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); 

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); // Impulse as we are only applying the force once 
    }

    private void ResetJump()
    {
        readyToJump = true; 
    }
}
