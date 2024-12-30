//Szymon Fijalkowski
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScreenManager : MonoBehaviour
{

    public Material defaultFace;
    public Material redFace;
    public Material offFace;
    public GameObject screen;
    private float faceFlash;
    private bool isOff;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RedFaceHandler());
        isOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FlashRedFace()
    {
        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                screen.GetComponent<MeshRenderer>().material = redFace;
            }
            else
            {
                screen.GetComponent<MeshRenderer>().material = defaultFace;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator RedFaceHandler()
    {
        while (true)
        {
            faceFlash = UnityEngine.Random.Range(0.1f, 2.0f);
            if (!isOff)
            {
                StartCoroutine(FlashRedFace());
            }
            yield return new WaitForSeconds(faceFlash);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("brick"))
        {
            StartCoroutine(TurnOff());
            isOff=true;
        }
    }

    private IEnumerator TurnOff()
    {
        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                screen.GetComponent<MeshRenderer>().material = offFace;
            }
            else
            {
                screen.GetComponent<MeshRenderer>().material = defaultFace;
                isOff=false;
            }
            yield return new WaitForSeconds(5f);
        }
    }
}
