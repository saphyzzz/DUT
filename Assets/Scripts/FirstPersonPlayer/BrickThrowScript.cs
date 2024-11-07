//Szymon Fijalkowski
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickThrowScript : MonoBehaviour
{
    //reference to the brick prefab
    public GameObject brick;
    public GameObject orientation;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(brick, new Vector3 (orientation.transform.position.x, (orientation.transform.position.y), orientation.transform.position.z), orientation.transform.rotation);
        }
    }
}
