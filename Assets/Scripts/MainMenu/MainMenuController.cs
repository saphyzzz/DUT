using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject background;
    public Sprite face;
    public Sprite empty;
    public Sprite eyes;
    public Sprite redFace;
    public Image dark;
    private int imageLength;
    private int imageChoice;
    private float extraFlashBreak;
    private float extraFaceFlash;
    private bool isFace;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        dark.gameObject.SetActive(false);
        StartCoroutine(ChangeImage());
        StartCoroutine(FlashScreenExtra());
        StartCoroutine(RedFaceHandler());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator ChangeImage()
    {

        //infinite loop
        while (true)
        {
            imageLength = UnityEngine.Random.Range(1, 8);
            StartCoroutine(FlashScreen());
            imageChoice = UnityEngine.Random.Range(1, 4);
            if (imageChoice == 1)
            {
                isFace = false;
                background.GetComponent<Image>().sprite = eyes;
            }
            if (imageChoice == 2)
            {
                isFace = false;
                background.GetComponent<Image>().sprite = empty;
            }
            if (imageChoice == 3)
            {
                isFace = true;
                background.GetComponent<Image>().sprite = face;
            }


            yield return new WaitForSeconds(imageLength);
        }
    }

    private IEnumerator FlashScreen()
    {
        

        for (int i = 0; i < 2; i++) 
        {
            if (i == 0)
            {
                dark.gameObject.SetActive(true);
            }
            else
            {
                dark.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator FlashScreenExtra()
    {
        while (true)
        {
            extraFlashBreak = UnityEngine.Random.Range(0.1f, 5.0f);
            StartCoroutine(FlashScreen());
            yield return new WaitForSeconds(extraFlashBreak);
        }
    }

    private IEnumerator FlashRedFace()
    {
        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                background.GetComponent<Image>().sprite = redFace;
            }
            else
            {
                background.GetComponent<Image>().sprite = face;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator RedFaceHandler()
    {
        while (true)
        {
            extraFaceFlash = UnityEngine.Random.Range(0.1f, 2.0f);
            if (isFace)
            {
                StartCoroutine(FlashRedFace());
            }
            yield return new WaitForSeconds(extraFaceFlash);
        }
    }

    // Quit game 
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game closed"); 
    }

    // Play game S
    public void Play()
    {
        SceneManager.LoadScene("FirstScene");
    }

}
