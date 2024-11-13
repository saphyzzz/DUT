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
        fuse = FindObjectOfType<Fuse>();
    }

    // Update is called once per frame
    void Update()
    {
        fuse = FindObjectOfType<Fuse>();
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
                pinkFuse.SetActive(false);
                blueFuse.SetActive(false);
                yellowFuse.SetActive(false);
                orangeFuse.SetActive(false);
                greenFuse.SetActive(false);   
                // Pick correct Brick UI         
                PickUi();
            }
            else if(player.hasFuse){
                // Pick correct Brick UI         
                PickUi();
                PickFuseUI();
            }
        }
    }

    // Picks which UI to use 
    public void PickUi(){
        if(player.brickCount == 1){
            brick1UI.SetActive(true);
            brick2UI.SetActive(false);
            defaultHudUI.SetActive(false);
        }
        else if(player.brickCount == 2){
            brick2UI.SetActive(true);
            brick1UI.SetActive(false);
            defaultHudUI.SetActive(false);
        }
        else if(player.brickCount <= 0){
            defaultHudUI.SetActive(true);
            brick2UI.SetActive(false);
            brick1UI.SetActive(false);
        }
    }

    // Pick Ui for fuse 
    public void PickFuseUI(){
        if(fuse.fuseColour==Fuse.FuseColour.PINK){
            pinkFuse.SetActive(true);
            blueFuse.SetActive(false);
            yellowFuse.SetActive(false);
            orangeFuse.SetActive(false);
            greenFuse.SetActive(false);   
        }
        if(fuse.fuseColour==Fuse.FuseColour.BLUE){
            blueFuse.SetActive(true);
            pinkFuse.SetActive(false);
            yellowFuse.SetActive(false);
            orangeFuse.SetActive(false);
            greenFuse.SetActive(false);   
        }
        if(fuse.fuseColour==Fuse.FuseColour.ORANGE){
            orangeFuse.SetActive(true);
            pinkFuse.SetActive(false);
            blueFuse.SetActive(false);
            yellowFuse.SetActive(false);
            greenFuse.SetActive(false);   
        }
        if(fuse.fuseColour==Fuse.FuseColour.YELLOW){
            yellowFuse.SetActive(true);
            pinkFuse.SetActive(false);
            blueFuse.SetActive(false);
            orangeFuse.SetActive(false);
            greenFuse.SetActive(false);   
        }
        if(fuse.fuseColour==Fuse.FuseColour.GREEN){
            greenFuse.SetActive(true);   
            pinkFuse.SetActive(false);
            blueFuse.SetActive(false);
            yellowFuse.SetActive(false);
            orangeFuse.SetActive(false); 
        }


    }
}
