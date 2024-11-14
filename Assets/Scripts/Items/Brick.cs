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

   // Handle audio
   public AudioSource source; 
   public AudioClip clip;




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
                  source.PlayOneShot(clip);
                  // Destroy brick and disable UI pop up 
                  // Destroy(gameObject); 
                  
                  // Start the Coroutine to handle audio and destruction
                  StartCoroutine(PickupBrick());

                  itemUI.SetActive(false);
               }

               else{
                  uiText.text = "Already have"; 
               }
            }
         }
      }

   private IEnumerator PickupBrick(){
      // Play the audio
      source.PlayOneShot(clip);

      // Wait for the length of the audio clip
      yield return new WaitForSeconds(clip.length);

      // Destroy the brick after the audio has played
      Destroy(gameObject);
   }
      


      // Check for collisions 
      private void OnTriggerEnter(Collider other)
      {
         if(other.gameObject.name.Contains("Player"))
         {
               // Set check for player collision and enable UI pop up 
               isPlayerInRange = true;
               itemUI.SetActive(true);
               
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
         }
      }
}


