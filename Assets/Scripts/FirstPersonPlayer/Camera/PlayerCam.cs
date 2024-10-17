// Avalon Brathwaite 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    // Mouse sensitivity multipliers 
    public float sensX; 
    public float sensY; 

    // Players orientation 
    public Transform orientation; 

    // X and Y rotation of the camera 
    float xRotation; 
    float yRotation; 

     // Handle States 
    public GameManager gameManager;  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
         // Check if the game is in pause menu
        if (gameManager.currentState ==  GameManager.GameState.PauseMenu)
        {
         // Lock cursor to the middle of the screen and make it visible 
             Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;; 
            return; // Exit the method if in pause menu
        }

        else if (gameManager.currentState == GameManager.GameState.InGame)
        {

            // Lock cursor to the middle of the screen and make it invisible 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; 
            
            // Get the horizontal mouse movement 
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            
            // Get the vertical mouse movement 
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            // Adds horizontal mouse movement (Left/Right) to current y-rotation, affecing rotation around the y axis 
            yRotation += mouseX; 

            // Subtracts vertical mouse movement (Up/Down) from the x-rotation, affecting rotation around the x-axis 
            xRotation -= mouseY; 
            
            // Only allow player to look up and down to a max of 90 degrees 
            xRotation = Mathf.Clamp(xRotation, -90, 90f);

            // Rotate camera and orientation 
            transform.rotation = Quaternion.Euler( xRotation, yRotation, 0 ); // Rotate camera on both x and y axis 
            orientation.rotation = Quaternion.Euler( 0, yRotation, 0 ); // Rotate the player around the y axis 
        }
    }
}
