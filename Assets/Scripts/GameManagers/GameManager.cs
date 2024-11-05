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
        Debug.Log("Press esc to pause");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == GameState.InGame){
            if (Input.GetKeyDown(KeyCode.Escape)){
                currentState = GameState.PauseMenu; 
                Debug.Log("We are now in " + currentState);
                Time.timeScale = 1; 
            }
        }
        else if(currentState == GameState.PauseMenu){
            if (Input.GetKeyDown(KeyCode.Escape)){
                currentState = GameState.InGame; 
                Debug.Log("We are now in " + currentState);
                Time.timeScale = 0; 
            }
        }
    }
}
