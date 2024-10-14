using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game States
    enum GameState{MainMenu, InGame, WinScreen, DefeatScreen}

    // Stores the current Game state
    GameState currentState = GameState.MainMenu; 

    // Store user input 
    string playersInput = ""; 


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("We are in gamestate: "+ currentState);
    }

    // Update is called once per frame
    void Update()
    {
        // Execute this code if our game state is in main menu 
        if (currentState == GameState.MainMenu) {
            if (Input.GetKeyDown(KeyCode.Keypad1)){
                Debug.Log(" We are now in the: " + currentState + " Press 1 to leave.");
            }
            currentState = GameState.InGame; 
        }

        else if (currentState == GameState.InGame){
            if (Input.GetKeyDown(KeyCode.Keypad1)){
                 Debug.Log("We are now in " + currentState + " Press 1 to leave. ");
            }
            currentState = GameState.MainMenu; 
        }
    }
}
