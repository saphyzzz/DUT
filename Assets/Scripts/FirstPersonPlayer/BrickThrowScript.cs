//Szymon Fijalkowski
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickThrowScript : MonoBehaviour
{
    //reference to the brick prefab
    public GameObject brick;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Instantiate(brick, transform.position, transform.rotation);
        }
    }
}
