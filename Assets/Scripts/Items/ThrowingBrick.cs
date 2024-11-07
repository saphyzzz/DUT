using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBrick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 2, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(transform.up * 1, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
