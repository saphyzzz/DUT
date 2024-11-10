using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBrick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int random_x = Random.Range(-100, 100);
        int random_y = Random.Range(-100, 100);
        int random_z = Random.Range(-100, 100);
        GetComponent<Rigidbody>().AddForce(transform.forward * 8, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(transform.up * 3, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddTorque(new Vector3(random_x,random_y,random_z));
        StartCoroutine(DeathTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ENEMY")
        {
            Destroy(gameObject);
        }
    }

    //coroutine to destroy the brick after a set amount of time
    private IEnumerator DeathTimer()
    {

        for (int i = 0; i < 5; i++)
        {
            if (i == 4)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1f);
        }

    }
}
