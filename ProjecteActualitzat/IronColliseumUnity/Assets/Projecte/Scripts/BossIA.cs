using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossIA : MonoBehaviour
{

    [Header ("Instances")]
    private NavMeshAgent agent;
    private Transform target;
    private Vector3 newPos;
    private BossBehaviour boss;

    [Header("RayAttack")]
    public float timeAttacking;
    public float attackingCounter;
    public float distance;
    public float laserDamage;
    private float restDamage;
    public float cadency;
    public float ammo;
    public float maxAmmo;
    public float cadencyCounter;
    public GameObject laser;
    public GameObject raySpawn;
    public bool canLaser;
    private FPSController player;
    public LineRenderer laserHit;

    [Header("LegAttack")]
    public GameObject areaAttack;
    public GameObject spawnAreaAttack;
    public float timeBetweenAreaAttacks;
    public float areaAttackCounter;
    public bool canLeg;

    [Header("AreaAttack")]
    public int maxRays;
    public int rays;
    public GameObject laserRay;
    public Transform center;
    public bool canArea;
    public float timeBetweenRayArea;
    public float rayAreaCounter;
    public bool isCenter;
    public GameObject shield;
    public bool inmune;

    [Header("Fases")]
    public bool fase2;
    public bool fase3;



    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        center = GameObject.FindGameObjectWithTag("Centre").GetComponent<Transform>();
        boss = GetComponent<BossBehaviour>();


        ammo = maxAmmo;
        canLaser = true;
        attackingCounter = 0;

        timeBetweenAreaAttacks = Random.Range(8f, 10f);
        canLeg = true;

        timeBetweenRayArea = Random.Range(9f, 11f);
        canArea = false;
        isCenter = false;
        inmune = false;
        shield.SetActive(false);
    }

    private void Update()
    {
        attackingCounter += Time.deltaTime;
        areaAttackCounter += Time.deltaTime;
        rayAreaCounter += Time.deltaTime;

        if (boss.life <= 25)
        {
            fase2 = true;
        }

        if (boss.life <= 15)
        {
            fase3 = true;
        }

        if (canArea == false)
        {
            transform.LookAt(target);
            MoveR();
        }

        

        if (attackingCounter >= timeAttacking && canArea == false)
        {
            if (canLaser)
            {
                LaserAttack();
                canLeg = true;
            }

            else
            {
                attackingCounter = 0;
                laser.SetActive(false);
                
            }
        }

        if (ammo <= 0)
        {
            ammo = 0;
            Reload();
        }

        if (areaAttackCounter >= timeBetweenAreaAttacks && canArea == false && fase2 == true)
        {
            if (canLeg)
            {
                LegAttack();
            }

            else
            {
                areaAttackCounter = 0;
            }
        }

        if (rayAreaCounter >= timeBetweenRayArea && fase3 == true)
        {
            if (isCenter == false)
            {
                AreaAttack();
            }
        }
        
    }

    private void MoveR()
    {
        newPos = transform.position + new Vector3(Random.onUnitSphere.x * 100, 1f, Random.onUnitSphere.z * 100);
        agent.SetDestination(newPos);
    }

    private void LaserAttack()
    {

        cadencyCounter += Time.deltaTime;

        RaycastHit hitInfo;

        if (cadencyCounter >= cadency && ammo > 0) 
        {
            
            laser.SetActive(true);

            if (Physics.Raycast(raySpawn.transform.position, raySpawn.transform.forward, out hitInfo, distance))
            {
                if (hitInfo.transform.CompareTag("Player"))
                {
                    player = hitInfo.transform.GetComponent<FPSController>();

                    if (player.shield > laserDamage)
                    {
                        player.ShieldDamage(laserDamage);
                    }
                    else if (player.shield <= laserDamage && player.shield > 0)
                    {
                        restDamage = laserDamage - player.shield;
                        player.GetDamage(restDamage);
                        player.shield = 0;
                        restDamage = 0;
                    }

                    else if (player.shield <= 0)
                    {
                        player.GetDamage(laserDamage);
                    }
                }

                ammo--;
            }

            cadencyCounter = 0;
            
        }



    }

    private void Reload()
    {
        StartCoroutine(WaitReload());
    }

    private void LegAttack()
    {

        
        canLaser = false;
        agent.isStopped = true;
        
        StartCoroutine(WaitLegAttack());
    }

    private void AreaAttack()
    {
        agent.isStopped = false;
        StopAllCoroutines();
        laser.SetActive(false);
        canArea = true;
        canLaser = false;
        canLeg = false;
        agent.SetDestination(center.position);

        var distance = (center.position - transform.position).magnitude;

        if (distance <= 0.2f)
        {
            StartCoroutine(WaitAreaAttack());
            isCenter = true;
        }


    }

    private IEnumerator WaitReload()
    {
        attackingCounter = 0;
        laser.SetActive (false);
        yield return new WaitForSeconds(3);
        ammo = maxAmmo;
    }

    private IEnumerator WaitLegAttack()
    {

        areaAttackCounter = 0;
        yield return new WaitForSeconds(1);
        Instantiate(areaAttack, spawnAreaAttack.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        canLeg = false;
        canLaser = true;
        agent.isStopped = false;
        timeBetweenAreaAttacks = Random.Range(8f, 10f);
    }

    private IEnumerator WaitAreaAttack()
    {
        shield.SetActive(true);
        boss.inmune = true;
        agent.isStopped = true;
        yield return new WaitForSeconds(1f);
        if (rays <= maxRays)
        {
            for (int i = 0; i < maxRays; i++)
            {
                var raig = Instantiate(laserRay, new Vector3(Random.Range(-20, 20), 8.5f, Random.Range(-20, 20)), Quaternion.identity);
                raig.transform.parent = gameObject.transform;
                rays++;
            }
        }

        yield return new WaitForSeconds(6f);
        agent.isStopped = false;
        shield.SetActive(false);
        boss.inmune = false;
        rayAreaCounter = 0;
        attackingCounter = 0;
        areaAttackCounter = 0;
        timeBetweenRayArea = Random.Range(20f, 30f);
        canLaser = true;
        canLeg = true;
        isCenter = false;
        canArea = false;

    }
}
