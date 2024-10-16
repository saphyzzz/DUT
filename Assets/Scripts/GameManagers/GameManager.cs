// Avalon Brathwaite 

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game States
    public enum GameState{PauseMenu, InGame, WinScreen, DefeatScreen}

    // Stores the current Game state
    public GameState currentState = GameState.InGame; 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("We are in gamestate: "+ currentState);
        Debug.Log("Press 1 to leave Pause menu, press 2 to go from InGame to Pause menu");
    }

    // Update is called once per frame
    void Update()
    {
        // Execute this code if our game state is in pause menu 
        if (currentState == GameState.PauseMenu) {
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                currentState = GameState.InGame; 
                Debug.Log(" We are now in the: " + currentState);
            }
        }

        if (currentState == GameState.InGame){
            if (Input.GetKeyDown(KeyCode.Alpha2)){
                currentState = GameState.PauseMenu; 
                Debug.Log("We are now in " + currentState);
            }
        }
    }
}
