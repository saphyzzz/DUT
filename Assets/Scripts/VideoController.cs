// Avalon Brathwaite 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public GameObject skipText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForVideoToEnd());
    }

    void Update(){

        //if E is pressed when the text is being displayed, load the main level
        if(Input.GetKeyDown(KeyCode.E) && skipText.activeSelf){
            SceneManager.LoadSceneAsync("FirstScene");
            SceneManager.UnloadSceneAsync("CinematicScene");
        }

        //if any key is pressed and the text isn't on screen start the coroutine
        if (Input.anyKeyDown && !skipText.activeSelf){
            StartCoroutine(EnableSkip());
        }
    }

    private IEnumerator WaitForVideoToEnd()
    {
        for (int i = 0; i < 2; i++)
        {
            if (i == 1)
            {
               SceneManager.LoadSceneAsync("FirstScene");
               SceneManager.UnloadSceneAsync("CinematicScene");     
            }
            yield return new WaitForSeconds(70f);
        }
    }
   
    //szymon fijalkowski
    //Coroutine to show text prompt on screen and in turn enable skipping for 3 seconds and then hide and disable it
    //this creates a two input confirmation process to ensure that the player wants to skip
    private IEnumerator EnableSkip()
    {
        for (int i = 0; i < 2; i++)
        {
            if (i == 0) { 
                skipText.SetActive(true);
            }

            else { 
                skipText.SetActive(false); 
            }

            yield return new WaitForSeconds(3f);
        }
    }
}
