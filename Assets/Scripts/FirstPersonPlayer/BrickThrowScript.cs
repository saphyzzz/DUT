//Szymon Fijalkowski
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickThrowScript : MonoBehaviour
{
    //reference to the brick prefab
    public GameObject brick;
    public GameObject orientation;
    private GameObject newBrick;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && player.brickCount != 0)
        {
            newBrick = Instantiate(brick, new Vector3 (orientation.transform.position.x, (orientation.transform.position.y)-0.5f, orientation.transform.position.z), orientation.transform.rotation);
            newBrick.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
            player.brickCount--;
        }
    }
}
