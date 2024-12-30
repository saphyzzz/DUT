// Avalon Brathwaite

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    public Player player; 
    public GameObject defeatScreenUI;
    public GameManager gameManager; 
    public AudioSource source; 
    public AudioClip fuseClip;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Check for collisions 
      private void OnCollisionEnter(Collision collision)
      {
         if(collision.gameObject.name.Contains("Player"))
         {
            Debug.Log("Hit player"); 
            gameManager.currentState = GameManager.GameState.DefeatScreen;
               
         }
      }

    //   private void OnTriggerExit(Collider other)
    //   {
    //      if(other.gameObject.name.Contains("Player"))
    //      {  
    //            // Reset check for player collision and disable UI pop up 
    //            isPlayerInRange = false;
    //            fuseboxUI.SetActive(false);
    //            uiText.text = "Place Fuse";
    //      }
    //   }
}
