using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [Header("Movement")]
    
    // Movement speed
    public float moveSpeed;

    // Oritentation of player 
    public Transform orientation; 

    // Keyboard input for horizontal and vertical
    float horizontalInput; 
    float verticalInput; 
    
    // Movement Direction 
    Vector3 moveDirection; 
    
    RigidBody rb; 

    public void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.freezeRotation = true; 
    }
}
