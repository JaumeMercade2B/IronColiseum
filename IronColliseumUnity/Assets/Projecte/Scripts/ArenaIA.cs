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

    public LayerMask whatIsPlayer;

    //public Transform enemy;

    //public Animator melee;
    public EnemyMele mele;

    public Transform spawnSightRange;
    public Transform afterMele;


    //States
    public float sightRange, attackRange, meleRange, shootRange;
    public bool playerInSightRange, playerInAttackRange, playerInMeleRange, enemyShootRange;

    public bool alreadyMele;

    public float meleCadency;
    public float meleTime;

    public bool moveRand;
    public bool chase;

    public bool hit;

    public float waitAtack;

    private EnemyBehaviour enemy;

    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        player = GameObject.Find("Player").transform;
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        agent = GetComponent<NavMeshAgent>();

        enemy = GetComponent<EnemyBehaviour>();
        canAttack = true;

        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);

        timeBetweenAttacks = Random.Range(1, 5);

        meleCadency = 0;
        moveRand = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levelManager.startArena == true)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            enemyShootRange = Physics.CheckSphere(transform.position, shootRange, whatIsPlayer);
            transform.LookAt(player);

        }

        if (levelManager.startArena == false)
        {
            Idle();
        }


        if (levelManager.startArena == true)
        {
            if (meleCadency <= 0 && playerInMeleRange == false)
            {
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            }

            else
            {
                playerInAttackRange = false;
            }

            if (meleCadency <= 0)
            {
                playerInMeleRange = Physics.CheckSphere(transform.position, meleRange, whatIsPlayer);

            }
            else
            {
                playerInMeleRange = false;
            }



            if (playerInSightRange == true && playerInAttackRange == false && playerInMeleRange == false)
            {

                AttackPlayer();
                MoveR();
                meleCadency -= Time.deltaTime;
                meleTime = 0;
                agent.speed = 8;


                waitAtack += Time.deltaTime;

                if (waitAtack >= 1f)
                {
                    canAttack = true;
                }

            }

            if (playerInAttackRange && playerInMeleRange == false)
            {
                playerInSightRange = false;
                moveRand = false;
                Chase();

            }

            if (playerInMeleRange && meleCadency <= 0)
            {
                playerInAttackRange = false;
                hit = true;
                meleAttack();
            }

            else
            {
                MoveR();
            }

            if (enemyShootRange)
            {
                canAttack = false;
            }
            else
            {
                canAttack = true;
            }
        }




    }

    private void MoveR()
    {

        if (enemy.dead == false)
        {
            agent.isStopped = false;
            agent.speed = 8;
            Debug.Log("Home");
            newPos = transform.position + new Vector3(Random.onUnitSphere.x * 100, 1f, Random.onUnitSphere.z * 100);
            agent.SetDestination(newPos);
            //StartCoroutine(Wait());
        }
        

    }

    private void AttackPlayer()
    {
        if (enemy.dead == false)
        {
            if (canAttack == false)
            {
                return;
            }

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


  

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void Idle()
    {
        agent.speed = 0;
        Debug.Log("IsIdle");
    }

    private void Chase()
    {

        if (enemy.dead == false)
        {
            agent.speed = 15;
            agent.SetDestination(player.position);
            canAttack = false;

            if (agent.remainingDistance <= meleRange)
            {
                agent.speed = 0;
            }
        }

    }

    private void meleAttack()
    {

        if (enemy.dead == false)
        {
            mele.Attack();
            //melee.SetBool("Melee", true);
            canAttack = false;

            meleTime += Time.deltaTime;

            if (meleTime >= 0.3f)
            {
                meleCadency = 3f;

                waitAtack = 0;
                mele.ReturnIdle();
                //melee.SetBool("Melee", false);


                agent.SetDestination(afterMele.position);

                if (agent.remainingDistance <= 0.1f)
                {
                    playerInSightRange = true;
                    playerInMeleRange = false;

                }


            }
        }

    }

    IEnumerator Wait()
    {
        stopped = Random.Range(0.5f, 1f);
        yield return new WaitForSeconds(stopped);
        agent.speed = 0;
        stopped = Random.Range(0.5f, 1f);
        agent.speed = 8f;


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    IEnumerator WaitMele()
    {
        yield return new WaitForSeconds(0.7f);
        meleAttack();
        yield return new WaitForSeconds(0.7f);
        alreadyMele = true;
        agent.isStopped = false;
        yield return new WaitForSeconds(5);
        alreadyMele = false;
        yield return new WaitForSeconds(1f);
        canAttack = true;


    }
}
