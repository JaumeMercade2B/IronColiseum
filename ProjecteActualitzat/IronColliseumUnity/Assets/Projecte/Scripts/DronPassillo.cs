using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DronPassillo : MonoBehaviour
{

    private NavMeshAgent agent;

    public float distance;

    public bool move;
    public bool chase;

    private Vector3 newPos;

    public bool playerSightRange;
    public float sightRange;

    private Transform player;

    public float restDamage = 0f;
    public float damage;
    public float damageExp;


    private FPSController playerController;

    private DronBehaviour dron;

    public LayerMask whatIsPlayer;

    private Vector3 mainTransform;

    public Collider col;
    public Collider trigger;

    public GameObject exp;

    public Transform expInst;

    public float ammo;
    public float maxAmmo;

    public float cadencyCounter;

    private Animator animator;

    private ImprovementCell start;

    public LogicaPassadís logica;

    // Start is called before the first frame update
    void Start()
    {
        dron = GetComponent<DronBehaviour>();

        agent = GetComponent<NavMeshAgent>();

        animator = GetComponentInChildren<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        start = GameObject.FindGameObjectWithTag("InteractCell").GetComponent<ImprovementCell>();


        move = false;
        chase = false;
        distance = 50f;
        //damage = 0.1f;

        col.enabled = true;
        trigger.enabled = true;

        ammo = maxAmmo;


    }

    // Update is called once per frame
    void Update()
    {

        if (start.doorOpen == true)
        {
            cadencyCounter += Time.deltaTime;

            if (dron.dead == false)
            {
                playerSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

            }

            if (move == true && dron.dead == false && ammo > 0)
            {
                MoveR();

            }

            if (dron.disolve <= 0 && dron.dead == false)
            {
                move = true;
            }

            //if (playerSightRange == true && dron.dead == false && ammo > 0)
            //{
            //    Chase();


            //    //mainTransform = transform.position;
            //    //mainTransform.y -= 0.3f * Time.deltaTime;


            //}

            if (ammo <= 0)
            {
                Explode();
            }

            if (dron.dead == true)
            {
                chase = false;
                move = false;
                playerSightRange = false;
                animator.SetTrigger("Death");
            }
        }

        if (dron.life <= 0)
        {
            if (dron.dead == false)
            {
                logica.enemyCounter++;
            }
        }
        

    }

    private void MoveR()
    {

        if (dron.dead == false)
        {
            transform.LookAt(player);

            agent.isStopped = false;
            agent.speed = 8;

            newPos = transform.position + new Vector3(Random.onUnitSphere.x * 2, 1f, Random.onUnitSphere.z * 2);
            agent.SetDestination(newPos);
            animator.SetTrigger("Accelerate");

            if (playerSightRange == true)
            {
                //transform.LookAt(player);
                Attack();
            }
        }

        else
        {
            agent.isStopped = true;
            agent.speed = 0;
        }

    }

    private void Chase()
    {

        if (dron.dead == false)
        {
            chase = true;

            //agent.SetDestination(player.position);
            MoveR();
            Attack();

            col.enabled = false;
        }

        else
        {
            agent.isStopped = true;
            agent.speed = 0;
        }
    }

    public void Explode()
    {
        agent.baseOffset -= 0.5f;
        agent.SetDestination(player.position);
        agent.speed = 15;

        if (agent.baseOffset <= 1)
        {
            agent.baseOffset = 1;
        }
    }

    public void Attack()
    {
        transform.LookAt(player);


        if (cadencyCounter >= 5)
        {

            animator.SetTrigger("Shoot");
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
            if (playerController.shield > damageExp)
            {
                playerController.ShieldDamage(damageExp);
            }
            else if (playerController.shield <= damageExp && playerController.shield > 0)
            {
                restDamage = damageExp - playerController.shield;
                playerController.GetDamage(restDamage);
                playerController.shield = 0;
                restDamage = 0;
            }

            else if (playerController.shield <= 0)
            {
                playerController.GetDamage(damageExp);
            }
            col.enabled = false;
            trigger.enabled = false;

            var explosion = Instantiate(exp, expInst.position, Quaternion.identity);
            explosion.transform.parent = playerController.transform;
            Destroy(gameObject);
        }
    }
}

