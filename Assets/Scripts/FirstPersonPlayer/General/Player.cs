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

    public Fuse currentFuse { get; internal set; }

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
    public void SetHasFuse(bool fuse){
        hasFuse = fuse; 
    }
}