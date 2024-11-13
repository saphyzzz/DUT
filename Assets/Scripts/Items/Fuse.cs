// Avalon Brathwaite 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuse : MonoBehaviour
{

    public Player player; 
    private bool isPlayerInRange;
    public GameObject itemUI; 
    public Text uiText; 
    public GameManager gameManager; 

    // Track colours of Fuses
    public enum FuseColour{PINK,BLUE,GREEN,YELLOW,ORANGE}
    public FuseColour fuseColour; 


    // Start is called before the first frame update
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
         // Check if the player is in range and has pressed "E"
         if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
         {
            if(player.hasFuse == false){
               uiText.text = "Pick up fuse";
               // Increment fuse count on player
               player.SetHasFuse(true); 
               player.currentFuse = this;

               // Disable UI pop up 
               itemUI.SetActive(false);
            }
            else{
                uiText.text = "Already have";
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
               
         }
      }

      private void OnTriggerExit(Collider other)
      {
         if(other.gameObject.name.Contains("Player"))
         {  
               // Reset check for player collision and disable UI pop up 
               isPlayerInRange = false;
               itemUI.SetActive(false);
         }
      }
}
