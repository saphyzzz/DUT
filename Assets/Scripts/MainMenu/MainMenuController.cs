using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject background;
    public Sprite face;
    public Sprite empty;
    public Sprite eyes;
    public Image dark;
    private int imageLength;
    private int imageChoice;
    private int extraFlashBreak;

    // Start is called before the first frame update
    void Start()
    {
        dark.gameObject.SetActive(false);
        StartCoroutine(ChangeImage());
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
            imageLength = UnityEngine.Random.Range(1, 10);
            StartCoroutine(FlashScreen());
            imageChoice = UnityEngine.Random.Range(1, 4);
            if (imageChoice == 1)
            {
                background.GetComponent<Image>().sprite = eyes;
            }
            if (imageChoice == 2)
            {
                background.GetComponent<Image>().sprite = empty;
            }
            if (imageChoice == 3)
            {
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
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator FlashScreenExtra()
    {
        while (true)
        {
            extraFlashBreak = UnityEngine.Random.Range(1, 5);
            StartCoroutine(FlashScreen());
            yield return new WaitForSeconds(extraFlashBreak);
        }
    }
}
