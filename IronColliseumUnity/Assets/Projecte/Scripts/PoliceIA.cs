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

    // Start is called before the first frame update
    void Start()
    {

        behaviour = GetComponent<FuckThePoliceBehaviour>();

        agent = GetComponent<NavMeshAgent>();
        move = true;
        stopMoving = 0;
        setStopMoving = 3;
        distance = 50f;
        damage = 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (behaviour.disolve <= 0)
        {
            stopMoving += 0.5f * Time.deltaTime;

        }


        if (move == true && behaviour.disolve <= 0)
        {
            MoveRandom();

        }

        if (canShoot == true && behaviour.disolve <= 0)
        {
            timeShooting += 0.5f * Time.deltaTime;

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

    public void MoveRandom()
    {
        agent.isStopped = false;
        agent.speed = 8;
        canShoot = false;

        newPos = transform.position + new Vector3(Random.onUnitSphere.x * 100, 1f, Random.onUnitSphere.z * 100);
        agent.SetDestination(newPos);

        if (stopMoving >= setStopMoving)
        {
            Attack();
            setTimeShooting = Random.Range(0.5f, 1f);
        }


    }

    public void Attack()
    {
        agent.isStopped = true;
        transform.LookAt(player);
        canShoot = true;
        move = false;



    }
}
