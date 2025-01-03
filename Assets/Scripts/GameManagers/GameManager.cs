// Avalon Brathwaite 

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Game States
    public enum GameState{PauseMenu, InGame, WinScreen, DefeatScreen}

    // Stores the current Game state
    public GameState currentState = GameState.InGame; 

    public GameObject winUI;
    public GameObject defeatUI;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Handle changes with states and make changes accordingly. 
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

        else if(currentState == GameState.WinScreen){
            winUI.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Escape)){
                SceneManager.LoadScene("MainMenu");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 1; 
            }
        }
        else if(currentState == GameState.DefeatScreen){
            defeatUI.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Escape)){
                SceneManager.LoadScene("MainMenu");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 1; 
            }
        }
    }
}
