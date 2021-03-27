using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceIA : MonoBehaviour
{

    private NavMeshAgent agent;

    public float distance;

    public bool move;

    public bool sightRange;
    public float playerSightrRange;

    public Transform player;

    private Vector3 newPos;

    public float stopMoving;
    public float setStopMoving;

    public bool canShoot;

    private FPSController playerController;

    public float damage;

    public float timeShooting;
    public float setTimeShooting;

    public float restDamage = 0f;

    private FuckThePoliceBehaviour behaviour;

    public bool playerInSight;

    public LayerMask whatIsPlayer;

    public float inRange = 50;

    public float patrolTime;
    public float patrolCounter;

    public float idleTime;
    public float idleCounter;

    public int canChase;

    public int ammo;
    public int maxAmmo;

    public bool reloading;

    public float cadency;
    public float cadencyCounter;

    public bool playerSeen;

    private Transform point1;
    private Transform point2;

    public int destPoint;
    // Start is called before the first frame update
    void Start()
    {

        behaviour = GetComponent<FuckThePoliceBehaviour>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        move = true;
        stopMoving = 0;
        setStopMoving = 3;
        distance = 50f;
        damage = 0.1f;
        cadency = 0.5f;
        cadencyCounter = 0;
        patrolCounter = 0;
        patrolTime = Random.Range(2f, 4f);

        idleCounter = 0;
        idleTime = Random.Range(1f, 2f);

        canChase = Random.Range(0, 10);

        playerSeen = false;

        point1 = GameObject.FindGameObjectWithTag("Point1").GetComponent<Transform>();
        point2 = GameObject.FindGameObjectWithTag("Point2").GetComponent<Transform>();
        destPoint = Random.Range(1, 2);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        playerInSight = Physics.CheckSphere(transform.position, inRange, whatIsPlayer);
        cadencyCounter += Time.deltaTime;

        if (ammo <= 0)
        {
            Reloading();
        }

        if (behaviour.disolve > 0)
        {
            Idle();
        }

        if (playerSeen == false && behaviour.disolve <= 0)
        {

            agent.isStopped = false;
            agent.speed = 7;
            NextPoint();

        }

        if (playerInSight == true && behaviour.disolve <= 0)
        {

            transform.LookAt(player);
            playerSeen = true;
            agent.speed = 12;
            Chase();

            if (canShoot == true && behaviour.disolve <= 0)
            {
                timeShooting += 0.5f * Time.deltaTime;

                if (cadencyCounter >= cadency)
                {
                    RaycastHit hit;

                    if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
                    {
                        if (hit.transform.CompareTag("Player"))
                        {
                            playerController = hit.transform.GetComponent<FPSController>();

                            if (playerController.shield > damage)
                            {
                                playerController.ShieldDamage(damage);
                            }
                            else if (playerController.shield <= damage && playerController.shield > 0)
                            {
                                restDamage = damage - playerController.shield;
                                playerController.GetDamage(restDamage);
                                playerController.shield = 0;
                                restDamage = 0;
                            }

                            else if (playerController.shield <= 0)
                            {
                                playerController.GetDamage(damage);
                            }

                        }

                        ammo--;
                        cadencyCounter = 0;
                        if (ammo <= 0)
                        {
                            ammo = 0;
                            Reloading();
                        }
                    }
                
                }
            }
        }

        if (playerInSight == false)
        {
            playerSeen = false;
        }

    }

    



    public void Attack()
    {
        agent.isStopped = true;
        canShoot = true;
        move = false;
        agent.isStopped = true;


    }

    void NextPoint()
    {

        if (destPoint == 1)
        {
            agent.SetDestination (point1.position);

            if (!agent.pathPending && agent.remainingDistance <= 0.5f)
            {
                destPoint = destPoint + 1;

                if (destPoint >= 3)
                {
                    destPoint = 1;
                }
            }

        }

        else if (destPoint == 2)
        {
            agent.SetDestination(point2.position);

            if (!agent.pathPending && agent.remainingDistance <= 0.5f)
            {
                destPoint = destPoint + 1;

                if (destPoint >= 3)
                {
                    destPoint = 1;
                }
            }
        }
       
        
    }

    public void Chase()
    {
        agent.SetDestination(player.position);
        agent.isStopped = false;

        if (!agent.pathPending && agent.remainingDistance <= Random.Range(5, 10))
        {
            Attack();
        }
    }



    public void Idle()
    {
        agent.isStopped = true;
    }

    public void Reloading()
    {
        StartCoroutine(WaitReload());
    }

    IEnumerator WaitReload()
    {
        reloading = true;
        ammo = maxAmmo;
        yield return new WaitForSeconds(2);
        reloading = false;
    }
}
