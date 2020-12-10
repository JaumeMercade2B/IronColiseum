using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArenaIA : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameManager gameManager;

    //public bool canShoot;

    private Vector3 newPos;

    public float stopped;

    public Transform player;

    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    public EnemyWeapon weapon;

    public bool canAttack;

    public float sightRange;

    public LayerMask whatIsPlayer;

    public Transform enemy;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        player = GameObject.Find("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        canAttack = true;

        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);

        timeBetweenAttacks = Random.Range(1, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AttackPlayer();

        if (canAttack)
        {
            
            agent.isStopped = false;
            MoveR();
        }

        if (canAttack == false)
        {
            agent.isStopped = true;
        }
       
        transform.LookAt(player);

        Collider[] hits = Physics.OverlapSphere(enemy.transform.position, sightRange, whatIsPlayer);

        for (int i = 0; i < hits.Length; i++)
        {
            Rigidbody rb = hits[i].attachedRigidbody;

            //while (rb != null)
            //{
            //    canAttack = false;
                
            //}

            //else
            //{
            //    canAttack = true;
            //}
        }
    }

    private void MoveR()
    {
        agent.isStopped = false;
        Debug.Log("Home");
        newPos = transform.position + new Vector3(Random.onUnitSphere.x * 100, 1f, Random.onUnitSphere.z * 100);
        agent.SetDestination(newPos);
        StartCoroutine(Wait());

    }

    private void AttackPlayer()
    {

        if (!alreadyAttacked && canAttack == true)
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

    IEnumerator Wait()
    {
        stopped = Random.Range(5f, 10f);
        yield return new WaitForSeconds(stopped);
        agent.speed = 0;
        stopped = Random.Range(0.5f, 1f);
        agent.speed = 8f;


    }
}
