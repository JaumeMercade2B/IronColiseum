using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class PolicePatrol : MonoBehaviour
{
    public GameObject target;

    public float sightRadius;
    public float attackRadius;
    public LayerMask whatIsPlayer;

    public bool playerInSight;
    public bool playerInAttack;

    public NavMeshAgent agent;

    public Transform[] points;
    public int destPoint = 0;

    public float speed;

    public float attackCooldown;
    public float startTimer;

    public bool attacking = false;

    public bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRadius, whatIsPlayer);
        playerInAttack = Physics.CheckSphere(transform.position, attackRadius, whatIsPlayer);

        if (!agent.pathPending && agent.remainingDistance <= 0.5f)
        {
            NextPoint();
        }



    }

    void NextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    void CheckDistance()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
    }

    void Attack()
    {
        agent.isStopped = true;
        canShoot = true;
        //move = false;
        agent.isStopped = true;

    }

    void GetDamage()
    {

    }
}
