// Avalon Brathwaite 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
   public Player player;
   private bool isPlayerInRange;
   public GameObject itemUI;
   public Text uiText;  
   public GameManager gameManager;


   void Start()
   {
      player = FindObjectOfType<Player>();
      gameManager = FindObjectOfType<GameManager>();
   }


   void Update()
      {
         if(gameManager.currentState != GameManager.GameState.InGame){
         itemUI.SetActive(false);
         return;
      }
      else{
         // Check if the player is in range and has pressed "E"
            if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
            {
               if(player.brickCount != 2)
               {
                  uiText.text = "Pick up brick";
                  // Increment brick count on player
                  player.IncrementBrickCount(1); 
                  Debug.Log("Brick picked up!");

                  // Destroy brick and disable UI pop up 
                  Destroy(gameObject); 
                  itemUI.SetActive(false);
               }

               else{
                  uiText.text = "Already have"; 
                  Debug.Log("Player has two bricks");
               }
            }
         }
      }

      // Check for collisions 
      private void OnTriggerEnter(Collider other)
      {
         if(other.gameObject.name.Contains("Player"))
         {
               // Set check for player collision and enable UI pop up 
               isPlayerInRange = true;
               itemUI.SetActive(true);
               Debug.Log("Player in range. Press 'E' to pick up brick.");
               
         }
      }

      private void OnTriggerExit(Collider other)
      {
         if(other.gameObject.name.Contains("Player"))
         {  
               // Reset check for player collision and disable UI pop up 
               isPlayerInRange = false;
               itemUI.SetActive(false);
               uiText.text = "Pick up brick";
               Debug.Log("Player out of range.");
         }
      }
}


