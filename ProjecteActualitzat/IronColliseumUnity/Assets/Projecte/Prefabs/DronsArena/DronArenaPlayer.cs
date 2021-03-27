using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DronArenaPlayer : MonoBehaviour
{

    private NavMeshAgent agent;
    private Transform player;
    private Vector3 newPos;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        newPos = transform.position + new Vector3(Random.onUnitSphere.x * 50, 1f, Random.onUnitSphere.z * 50);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        agent.SetDestination(newPos);

        if (agent.remainingDistance <= 0.5f)
        {
            newPos = transform.position + new Vector3(Random.onUnitSphere.x * 50, 1f, Random.onUnitSphere.z * 50);
        }
    }
}
