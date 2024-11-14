// Avalon Brathwaite

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuseBpx : MonoBehaviour
{
    public Player player; 
    private bool isPlayerInRange;
    public GameObject fuseboxUI; 
    public Text uiText; 
    public int fuseCount;
    public GameManager gameManager; 

    // Handle audio 
   public AudioSource source; 
   public AudioClip fuseClip;
   public AudioClip winClip;
   

    // Start is called before the first frame update
    void Start()
    {
      fuseCount = 0; 
    }

    // Update is called once per frame
    void Update()
    {
      if(gameManager.currentState != GameManager.GameState.InGame){
         fuseboxUI.SetActive(false);
         return;
      }

      // If player has four fuses switch to win state
      if(fuseCount == 5){
         gameManager.currentState = GameManager.GameState.WinScreen;
         source.PlayOneShot(winClip);
      }

      else{
         // Check if the player is in range and has pressed "E"
            if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
            {
               if(player.hasFuse){
                  uiText.text = "Place Fuse";
                  // Reset fuse
                  player.SetHasFuse(false); 

                  // Increment counter
                  fuseCount++; 

                  // Disable UI pop up and play audio 
                  source.PlayOneShot(fuseClip);
                  fuseboxUI.SetActive(false);
               }
               else{
                  uiText.text = "  No fuse";
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
               fuseboxUI.SetActive(true);
               
         }
      }

      private void OnTriggerExit(Collider other)
      {
         if(other.gameObject.name.Contains("Player"))
         {  
               // Reset check for player collision and disable UI pop up 
               isPlayerInRange = false;
               fuseboxUI.SetActive(false);
               uiText.text = "Place Fuse";
         }
      }
}
