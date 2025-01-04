using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
    public Transform player;
    public EnemyScreenManager barbra;
    public FuseBox fuseBox;
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (barbra.isOff)
        {
            agent.speed = 0f;
        }
        else
        {
            agent.speed = 3.5f + (fuseBox.fuseCount * 1.5f);
        }
        agent.destination = player.position;
    }
}
