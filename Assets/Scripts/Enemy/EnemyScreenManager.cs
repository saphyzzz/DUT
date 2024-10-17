using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScreenManager : MonoBehaviour
{

    public Material defaultFace;
    public Material redFace;
    private float faceFlash;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RedFaceHandler());
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
                GetComponent<MeshRenderer>().material = redFace;
            }
            else
            {
                GetComponent<MeshRenderer>().material = defaultFace;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator RedFaceHandler()
    {
        while (true)
        {
            faceFlash = UnityEngine.Random.Range(0.1f, 2.0f);
            StartCoroutine(FlashRedFace());
            yield return new WaitForSeconds(faceFlash);
        }
    }
}
