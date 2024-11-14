// Avalon Brathwaite 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{

    // Handle States 
    public GameManager gameManager;  

    // UI
    public GameObject defaultHudUI; 
    public GameObject brick1UI;
    public GameObject brick2UI;
    public GameObject pinkFuse; 
    public GameObject blueFuse;
    public GameObject orangeFuse; 
    public GameObject greenFuse; 
    public GameObject yellowFuse;  

    // Track bricks and fuses 
    public Player player; 
    public Fuse fuse; 

    // Start is called before the first frame update
    void Start()
    {
        fuse = player.currentFuse;
        //fuse = FindObjectOfType<Fuse>();
    }

    // Update is called once per frame
    void Update()
    {
         fuse = player.currentFuse;
         // Check if the game is inGame state
        if (gameManager.currentState !=  GameManager.GameState.InGame)
        {
            // Disable brick UI
            defaultHudUI.SetActive(false);
            brick1UI.SetActive(false);
            brick2UI.SetActive(false);

            // Disable Fuse UI if player does not have one 
            pinkFuse.SetActive(false);
            blueFuse.SetActive(false);
            yellowFuse.SetActive(false);
            orangeFuse.SetActive(false);
            greenFuse.SetActive(false);   
        }

        else if(gameManager.currentState ==  GameManager.GameState.InGame){ 
            // Check if a player has a fuse and set it to the correct UI
            if(!player.hasFuse){
                // Disable Fuse UI if player does not have one 
                disableFuseUI();
                
                // Pick correct Brick UI         
                PickUi();
            }
            else if(player.hasFuse){
                // Pick correct Brick UI         
                PickUi();
                PickFuseUI();
                // After setting the UI, delete the fuse object
                if (fuse!= null)
                {
                    Destroy(fuse.gameObject);
                    fuse = null;  // Reset the reference after deletion
                }
            }
        }
    }

    // Picks which UI to use 
    public void PickUi(){
        brick1UI.SetActive(false);
        brick2UI.SetActive(false);
        defaultHudUI.SetActive(false);

        if(player.brickCount == 1){
            brick1UI.SetActive(true);
        }
        else if(player.brickCount == 2){
            brick2UI.SetActive(true);
        }
        else if(player.brickCount <= 0){
            defaultHudUI.SetActive(true);
        }
    }

    public void PickFuseUI(){
        // Disable all fuse UI icons first
        disableFuseUI();

        // Enable only the correct fuse based on the colour
        switch (fuse.fuseColour)
        {
            case Fuse.FuseColour.PINK:
                pinkFuse.SetActive(true);
                break;
            case Fuse.FuseColour.BLUE:
                blueFuse.SetActive(true);
                break;
            case Fuse.FuseColour.ORANGE:
                orangeFuse.SetActive(true);
                break;
            case Fuse.FuseColour.YELLOW:
                yellowFuse.SetActive(true);
                break;
            case Fuse.FuseColour.GREEN:
                greenFuse.SetActive(true);
                break;
        }
    }

    // Disables fuse UI 
    public void disableFuseUI(){
        pinkFuse.SetActive(false);
        blueFuse.SetActive(false);
        orangeFuse.SetActive(false);
        greenFuse.SetActive(false);
        yellowFuse.SetActive(false);
    }

}
