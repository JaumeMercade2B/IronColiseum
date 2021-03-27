using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAArena : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject projectile;

    public EnemyWeapon weapon;

    public float speed;

    [SerializeField] private float timeToDash;
    [SerializeField] private float waitDash;
    [SerializeField] private float timeDashing;
    [SerializeField] private float stopDashing;
    [SerializeField] private bool canDash;




    private Rigidbody rb;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Transform enemy;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        //weapon = GetComponentInChildren<EnemyWeapon>();
        rb = GetComponent<Rigidbody>();

        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);

        waitDash = Random.Range(5, 10);
        timeBetweenAttacks = Random.Range(1, 5);

    }

    private void FixedUpdate()
    {
        //Comproba si el jugador esta aprop y el rang d'attack
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange) walkPointSet = false;

        Collider[] hits = Physics.OverlapSphere(transform.position, sightRange);

        for (int i = 0; i < hits.Length; i++)
        {
            Rigidbody rb = hits[i].attachedRigidbody;

            if (rb != null)
            {
                SearchWalkPoint();
            }
        }

        Patroling();
        AttackPlayer();

        timeToDash += Time.deltaTime;

        if (timeToDash >= waitDash)
        {
            Dash();
        }
        
    }

    private void Patroling()
    {
        transform.LookAt(player);

        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Quan ja ha arribat a walkpoint
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

    }

    private void SearchWalkPoint()
    {
        //Calcula un punt de rang aleatori
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

        if (agent.remainingDistance <= 5f)
        {
            Vector3 newPos = transform.position + new Vector3(Random.onUnitSphere.x * 5, 1f, Random.onUnitSphere.z * 5);
            agent.SetDestination(newPos);

        }

        else
        {
            agent.SetDestination(player.position);

        }


    }

    private void AttackPlayer()
    {
        //Fa que l'enemic no es mogui
        //agent.SetDestination(transform.position);
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Quan ja ha arribat a walkpoint
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

        

        if (!alreadyAttacked)
        {
            //Codi del attack
            //Instantiate(projectile, transform.position, Quaternion.identity);

            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

            //
            weapon.Shoot();
            timeBetweenAttacks = Random.Range(1, 5);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void Dash()
    {
        agent.speed = 50;
        StartCoroutine(Dashing());

    }

    //Visualizar rang d'attack y vista
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemy.transform.position, sightRange);
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    IEnumerator Dashing()
    {
        yield return new WaitForSeconds(0.3f);
        agent.speed = 8;
        timeToDash = 0;
        waitDash = Random.Range(5, 10);

    }


}
