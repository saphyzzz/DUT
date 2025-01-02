// Avalon Brathwaite

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UI;

public class TestTrigger : MonoBehaviour
{
    public Player player; 
    public GameObject defeatScreenUI;
    public GameManager gameManager; 
    public AudioSource source; 
    public AudioSource inGameSource;
    public GameObject panel;
    public Sprite mouthClosed;
    public Sprite mouthOpen;
    private bool isOpen;
    


    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Check for collisions 
      private void OnCollisionEnter(Collision collision)
      {
         if(collision.gameObject.name.Contains("Player"))
         { 
            gameManager.currentState = GameManager.GameState.DefeatScreen;
            StartCoroutine(Laugh());
            source.Play();
            inGameSource.Stop();
         }
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
