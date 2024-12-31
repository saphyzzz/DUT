using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimation : MonoBehaviour
{
    public GameObject body;
    public float maxDistance;
    public float stepWidth;
    public float footoffset;
    private Vector3 currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = currentPosition;

        Ray ray = new Ray(body.transform.position + (body.transform.right * stepWidth), Vector3.down);
        if (Physics.Raycast(ray,out RaycastHit hitInfo))
        {
            if (Vector3.Distance(currentPosition, hitInfo.point) > maxDistance)
            {
                currentPosition = hitInfo.point + (transform.forward);
            }
        }
    }
}