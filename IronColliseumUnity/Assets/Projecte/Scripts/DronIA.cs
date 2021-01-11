using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DronIA : MonoBehaviour
{

    private NavMeshAgent agent;

    public float distance;

    public bool move;
    public bool chase;

    private Vector3 newPos;

    public bool  playerSightRange;
    public float sightRange;

    public Transform player;

    public float restDamage = 0f;
    public float damage;

    private FPSController playerController;

    private DronBehaviour dron;

    public LayerMask whatIsPlayer;

    private Vector3 mainTransform;

    public Collider col;
    public Collider trigger;

    public GameObject exp;

    public Transform expInst;

    // Start is called before the first frame update
    void Start()
    {
        dron = GetComponent<DronBehaviour>();

        agent = GetComponent<NavMeshAgent>();

        move = false;
        chase = false;
        distance = 50f;
        damage = 0.5f;

        col.enabled = true;
        trigger.enabled = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (dron.dead == false)
        {
            playerSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        }

        if (move == true && dron.dead == false)
        {
            MoveR();
           
        }

        if (dron.disolve <= 0 && chase == false && dron.dead == false)
        {
            move = true;
        }

        if (playerSightRange == true && dron.dead == false)
        {
            Chase();


            //mainTransform = transform.position;
            //mainTransform.y -= 0.3f * Time.deltaTime;

            agent.baseOffset -= 0.5f;


            if (agent.baseOffset <= 1)
            {
                agent.baseOffset = 1;
            }
        }

        if (dron.dead == true)
        {
            chase = false;
            move = false;
            playerSightRange = false;
        }

    }

    private void MoveR()
    {

        if (dron.dead == false)
        {
            agent.isStopped = false;
            agent.speed = 8;

            newPos = transform.position + new Vector3(Random.onUnitSphere.x * 100, 1f, Random.onUnitSphere.z * 100);
            agent.SetDestination(newPos);
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

            transform.LookAt(player);
            agent.SetDestination(player.position);

            col.enabled = false;
        }

        else
        {
            agent.isStopped = true;
            agent.speed = 0;
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
            col.enabled = false;
            trigger.enabled = false;

            var explosion = Instantiate(exp, expInst.position, Quaternion.identity);
            explosion.transform.parent = playerController.transform;
            Destroy(gameObject);
        }
    }
}
