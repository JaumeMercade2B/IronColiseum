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
        if (playerInSight == true && reloading == false)
        {

            transform.LookAt(player);

            //if (behaviour.disolve <= 0)
            //{
                

            //}


            if (move == true && behaviour.disolve <= 0)
            {

                if (canChase < 5)
                {
                    stopMoving += 0.5f * Time.deltaTime;
                    MoveRandom();

                }

                if (canChase >= 5)
                {
                    //stopMoving = 1000;
                    Chase();
                }

            }

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
                        }
                    }
                
                }

                if (timeShooting >= setTimeShooting)
                {
                    canShoot = false;
                    move = true;
                    
                    stopMoving = 0;
                    setStopMoving = Random.Range(2f, 4f);
                }
            }
        }

        else if (playerInSight == false && reloading == false)
        {
            canChase = Random.Range(0, 10);

            if (behaviour.disolve <= 0)
            {
                patrolCounter += Time.deltaTime;


                if (patrolCounter < patrolTime)
                {

                    Patrol();

                    idleTime = Random.Range(1f, 2f);
                    idleCounter = 0;
                }

                else if (patrolCounter >= patrolTime)
                {

                    idleCounter += Time.deltaTime;
                    Idle();


                }

                if (idleCounter >= idleTime)
                {

                    patrolCounter = 0;
                    patrolTime = Random.Range(2f, 4f);
                    idleCounter = 0;
                    //Patrol();
                }

            }
        }
            


    }

    public void MoveRandom()
    {
        agent.isStopped = false;
        agent.speed = 10;
        canShoot = false;

        newPos = transform.position + new Vector3(Random.onUnitSphere.x * 100, 1f, Random.onUnitSphere.z * 20);
        agent.SetDestination(newPos);

        if (stopMoving >= setStopMoving)
        {
            timeShooting = 0;
            Attack();
            setTimeShooting = Random.Range(1f, 2f);
        }


    }

    public void Attack()
    {
        agent.isStopped = true;
        canShoot = true;
        move = false;
        agent.isStopped = true;


    }

    public void Chase()
    {
        agent.isStopped = false;

        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance <= 5f)
        {
            timeShooting = 0;
            Attack();
        }
    }

    public void Patrol()
    {
        agent.isStopped = false;
        agent.speed = 10;
        canShoot = false;

        newPos = transform.position + new Vector3(Random.onUnitSphere.x * 100, 1f, Random.onUnitSphere.z * 200);
        agent.SetDestination(newPos);
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
