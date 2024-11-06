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

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

   
   void Update()
      {
         // Check if the player is in range and has pressed "E"
         if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
         {
            if(player.hasFuse == false){
               uiText.text = "Pick up fuse";
               // Increment fuse count on player
               player.SetHasFuse(); 
               Debug.Log("Fuse picked up!");

               // Destroy fuse and disable UI pop up 
               Destroy(gameObject); 
               itemUI.SetActive(false);
            }
            else{
                uiText.text = "Already have";
                Debug.Log("Player has fuse");
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
               Debug.Log("Player in range. Press 'E' to pick up fuse.");
               
         }
      }

      private void OnTriggerExit(Collider other)
      {
         if(other.gameObject.name.Contains("Player"))
         {  
               // Reset check for player collision and disable UI pop up 
               isPlayerInRange = false;
               itemUI.SetActive(false);
               Debug.Log("Player out of range.");
         }
      }
}
