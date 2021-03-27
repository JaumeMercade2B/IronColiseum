using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PoliceTaller : MonoBehaviour
{

    private NavMeshAgent agent;
    private SearchPoint point;

    public Transform destination;
    private Transform player;
    private FPSController playerController;


    public bool goPoint;
    public bool walkingPlayerRange;


    public int randomBehaviour;

    public float cadency;
    public bool canShoot;
    public float cadencyCounter;
    public float damage;
    private float restDamage;
    public float ammo;
    public bool reloading;
    public float maxAmmo;
    public Transform shootSpawn;
    public bool playerIsSight;
    public LayerMask whatIsPlayer;

    public float life;

    public bool dead;

    private Material dissolveMat;
    public float dissolve;
    public Renderer enemyRender;

    private LogicaTaller logica;

    public GameObject weapon;


    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.FindGameObjectWithTag("Points").GetComponent<SearchPoint>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        logica = GameObject.FindGameObjectWithTag("LogicaTaller").GetComponent<LogicaTaller>();

        dissolveMat = enemyRender.material;
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();


        agent = GetComponent<NavMeshAgent>();

        randomBehaviour = 0;

        goPoint = true;
        canShoot = false;
        reloading = false;
        dead = false;
        cadencyCounter = 0;
        life = Random.Range(4f, 7f);
        ammo = maxAmmo;

        dissolve = 1;
        dissolveMat.SetFloat("Vector1_283E90B", dissolve);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (dissolve > 0 && dead == false)
        {
            Appear();

        }

        if (dead == false && dissolve <= 0)
        {
            cadencyCounter += Time.deltaTime;

            if (randomBehaviour <= 4)
            {

                walkingPlayerRange = Physics.CheckSphere(transform.position, 10, whatIsPlayer);

                if (goPoint)
                {
                    MoveTo();
                }

                if (walkingPlayerRange && agent.remainingDistance > 1f)
                {
                    goPoint = false;
                    randomBehaviour = 9;

                }

                if (agent.remainingDistance <= 0.5f)
                {

                    if (goPoint == true)
                    {
                        point.pointCounter++;
                        goPoint = false;
                    }
                    

                    playerIsSight = Physics.CheckSphere(transform.position, 20, whatIsPlayer);

                    if (playerIsSight)
                    {

                        Vector3 lookAt = player.position;
                        lookAt.y = transform.position.y;
                        transform.LookAt(lookAt);
                        shootSpawn.transform.LookAt(player);
                        weapon.transform.LookAt(player);
                        Shoot();
                    }

                }

            }

            else if (randomBehaviour > 4)
            {
                agent.speed = 8;
                agent.SetDestination(player.transform.position);

                if (agent.remainingDistance <= Random.Range(5f, 10f))
                {
                    agent.speed = 0;
                    transform.LookAt(player);
                    Shoot();
                }
            }

         
        }
        if (life <= 0)
        {

            if (dead == false)
            {
                logica.deadEnemies++;
            }
            Dead();
        }



    }


    public void MoveTo()
    {
        point.GetPoint(destination);

        agent.SetDestination(destination.transform.position);

    }


    public void Shoot()
    {

            if (cadencyCounter >= cadency && reloading == false)
            {
                RaycastHit hit;

                if (Physics.Raycast(shootSpawn.transform.position, shootSpawn.transform.forward, out hit, Mathf.Infinity))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                    Debug.Log("Player");
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

    public void GetDamage (float damage)
    {
        life -= damage;
    }

    public void Appear()
    {
        if (dissolve >= 0)
        {
            dissolve -= 0.5f * Time.deltaTime;
            dissolveMat.SetFloat("Vector1_283E90B", dissolve);

            if (dissolve <= 0)
            {
                dissolve = 0;
            }

        }
}

    public void Disappear()
    {
        //dissolve = 0;

        dissolve += 0.1f * Time.deltaTime;
        dissolveMat.SetFloat("Vector1_283E90B", dissolve);
    }

    public void Dead()
    {
        
        Disappear();
        dead = true;
        agent.enabled = false;
        reloading = true;

        if (dissolve <= 0)
        {
            Destroy(gameObject);

        }
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

    private void OnDestroy()
    {
        Destroy(dissolveMat);
    }

}
