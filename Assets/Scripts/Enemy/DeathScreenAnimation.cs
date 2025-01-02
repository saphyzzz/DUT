//Szymon Fijalkowski
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenAnimation : MonoBehaviour
{
    public GameObject panel;
    public Sprite mouthClosed;
    public Sprite mouthOpen;
    private bool isOpen;

    void Start()
    {
        StartCoroutine(Laugh());
    }

    private IEnumerator Laugh()
    {
        while (true)
        {
            if (isOpen)
            {
                panel.GetComponent<Image>().sprite = mouthClosed;
                isOpen = false;
            }
            else
            {
                panel.GetComponent<Image>().sprite = mouthOpen;
                isOpen = true;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
