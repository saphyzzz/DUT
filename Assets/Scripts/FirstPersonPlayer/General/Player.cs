// Avalon Brathwaite 
// Handles collisions with player, inventory of bricks and collecting fuses

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Boolean hasFuse; 
    public int brickCount; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Increment amount of bricks a player has 
    public void IncrementBrickCount(int num){
        brickCount++; 
    }

    // Decrement amount of bricks a player has  
    public void DecrementBrickCount(){
        brickCount--; 
    }

    // Throw a brick 
    public void ThrowBrick(){
        // Check if player has bricks 
        if(brickCount == 0){
            return; 
        }
    }

    // Player has picked up a fuse
    public void SetHasFuse(){
        hasFuse = true; 
        Debug.Log("Fuse is now: " + hasFuse);
    }

    // Player has placed a fuse 
    public void UnsetHasFuse(){
        hasFuse = false; 
    }
}



// For fuses - 
/*
If a player collides with a fuse collision box and presses e we set the boolean hasFuse to true, 
The fuse box will need to have a script where if a player presses e while in its collison box hasFuse will be
set to false by passing in a player object to its script. The hasTrue boolean can be used to set the image of the fuse in the HUD
to active. Once hasFuse is false, this image will be deactived using SetActive(false). 

*/