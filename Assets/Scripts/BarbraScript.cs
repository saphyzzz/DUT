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
    public AudioClip defeatClip;
    public AudioSource inGameSource;


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
            gameManager.currentState = GameManager.GameState.DefeatScreen;
            source.PlayOneShot(defeatClip);
            inGameSource.Stop(); 
         }
      }
}
