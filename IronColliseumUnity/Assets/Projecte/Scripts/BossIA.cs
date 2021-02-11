using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossIA : MonoBehaviour
{
    private NavMeshAgent agent;

    private BossBehaviour boss;

    private Transform player;

    public Transform spawnBullet;

    public GameObject bullet;

    public float timeBetweenShoot;
    public float shootCounter;

    public float stoppedTime;
    public float stopCounter;

    public bool alreadyShot;

    public Transform specialSpawn;
    public bool specialDone;

    public float specialTime;
    public float specialCounter;

    public int misil;

    public GameObject electric;

    public float timeSecond;
    public float secondWait;


    // Start is called before the first frame update
    void Start()
    {
        boss = GetComponent<BossBehaviour>();
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        shootCounter = 0;

        timeBetweenShoot = Random.Range(4f, 6f);
        stoppedTime = 2f;

        alreadyShot = false;
        specialDone = false;

        specialTime = Random.Range(5f, 10f);

    }

    // Update is called once per frame
    void Update()
    {
        specialCounter += Time.deltaTime;


        if (specialCounter < specialTime)
        {
            shootCounter += Time.deltaTime;
            stopCounter += Time.deltaTime;

            transform.LookAt(player);

            if (shootCounter < timeBetweenShoot)
            {
                alreadyShot = false;
                stopCounter = 0;
                MoveRand();
            }

            if (shootCounter >= timeBetweenShoot)
            {

                ShootWeapon();
            }
        }

        if (specialCounter >= specialTime)
        {
            ShootMisil();
        }

    }

    private void Idle()
    {
        agent.isStopped = true;
    }

    private void MoveRand()
    {
        agent.isStopped = false;
        agent.speed = 15;

        Vector3 newPos;

        newPos = transform.position + new Vector3(Random.onUnitSphere.x * 250, 1f, Random.onUnitSphere.z * 250);
        agent.SetDestination(newPos);

    }

    private void ShootWeapon()
    {
        agent.isStopped = true;
        agent.speed = 0;

        if (alreadyShot == false)
        {
            Instantiate(bullet, spawnBullet.transform.position, Quaternion.identity);
            alreadyShot = true;
        }

        if (stopCounter >= stoppedTime)
        {
            shootCounter = 0;
        }

    }

    private void ShootMisil()
    {
        misil = Random.Range(1, 2);
        StartCoroutine(Misil());
    }

    IEnumerator Misil()
    {
        agent.isStopped = true;
        agent.speed = 0;

        Instantiate(electric, specialSpawn.transform.position, Quaternion.identity);

        if (misil == 2)
        {
            yield return new WaitForSeconds(1);
            Instantiate(electric, specialSpawn.transform.position, Quaternion.identity);
            specialTime = Random.Range(5f, 10f);
            shootCounter = 0;

            specialCounter = 0;
        }
        if (misil == 1)
        {
            specialTime = Random.Range(5f, 10f);
            shootCounter = 0;
            specialCounter = 0;

        }
    }
}
