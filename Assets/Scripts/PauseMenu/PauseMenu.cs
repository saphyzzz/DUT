// Avalon Brathwaite

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    // Handle States 
    public GameManager gameManager;  

    // UI
    public GameObject pauseMenuUI; 
    public GameObject pixelRenderUI;
    public GameObject itemUI;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
         // Check if the game is in pause menu state
        if (gameManager.currentState !=  GameManager.GameState.PauseMenu)
        {
            // PUT RESUME HERE IN FUTURE WHEN DEBUG MESSAGE IS GONE
            pixelRenderUI.SetActive(true); 
            pauseMenuUI.SetActive(false); 
            Time.timeScale = 1;
            return; // Exit the method if in Main Menu state
        }

        else if (gameManager.currentState == GameManager.GameState.PauseMenu)
        {   
            pause(); 
        }
    }

    // Pause the game 
    public void pause()
    {
        pauseMenuUI.SetActive(true);
        pixelRenderUI.SetActive(false);
        Time.timeScale = 0; 
    }

    // Set state back to InGame
    public void Resume()
    {
        Debug.Log("Back to in game");
        pixelRenderUI.SetActive(true); 
        pauseMenuUI.SetActive(false); 
        gameManager.currentState = GameManager.GameState.InGame; 
        Time.timeScale = 1;
    }

    // Load the main menu 
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading Menu");
    }
}
