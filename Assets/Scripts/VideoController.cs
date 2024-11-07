// Avalon Brathwaite 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    int time; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForVideoToEnd());
    }

    void update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("FirstScene");
        }
    }

    private IEnumerator WaitForVideoToEnd()
    {
        for (int i = 0; i < 2; i++)
        {
            if (i == 1)
            {
                SceneManager.LoadScene("FirstScene");
            }
            yield return new WaitForSeconds(70f);
        }
    }
}
