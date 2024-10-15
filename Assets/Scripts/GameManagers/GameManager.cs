using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game States
    public enum GameState{MainMenu, InGame, WinScreen, DefeatScreen}

    // Stores the current Game state
    public GameState currentState = GameState.MainMenu; 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("We are in gamestate: "+ currentState);
        Debug.Log("Press 1 to leave main menu, press 2 to go from InGame to main menu");
    }

    // Update is called once per frame
    void Update()
    {
        // Execute this code if our game state is in main menu 
        if (currentState == GameState.MainMenu) {
            if (Input.GetKeyDown(KeyCode.Keypad1)){
                currentState = GameState.InGame; 
                Debug.Log(" We are now in the: " + currentState);
            }
        }

        if (currentState == GameState.InGame){
            if (Input.GetKeyDown(KeyCode.Keypad2)){
                currentState = GameState.MainMenu; 
                Debug.Log("We are now in " + currentState);
            }
        }
    }
}
