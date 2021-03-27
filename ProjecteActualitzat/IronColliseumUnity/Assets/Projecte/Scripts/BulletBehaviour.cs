using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 30f;
    private float range;
    public float maxRange;
    public float damage = 1;

    //public GameObject explosionPrefab;
    

    private EnemyBehaviour  enemy;
    private FuckThePoliceBehaviour fuckPolice;
    private DronBehaviour dron;
    private DestroyTorreta destroyTorreta;
    private SegurataBehaviour segurata;
    private PassilloPolice pPolice;
    private PoliceTaller tallerPolice;
    private BarrelExp barril;



    private BossBehaviour boss;
    private FPSController player;

    public GameObject bullet;
    public GameObject muzzle;

    public Collider col;
    private ImprovementCell improve;

    private Arma arma;

    // Start is called before the first frame update
    void Start()
    {
        bullet.SetActive(true);
        muzzle.SetActive(false);

        maxRange = 30;
        arma = GameObject.FindGameObjectWithTag("Arma").GetComponent<Arma>();

        damage = arma.damage;
        
    }

    // Update is called once per frame
    virtual public void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        range += Time.deltaTime;

        if (range >= maxRange)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Boundaries")
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {      
            Destroy(gameObject);
        }

        if (other.tag == "Enemy")
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBehaviour>();
            col.enabled = false;
            gameObject.transform.parent = enemy.transform;
            speed = 0;
            bullet.SetActive(false);
            muzzle.SetActive(true);
            enemy = other.gameObject.GetComponent<EnemyBehaviour>();
            enemy.GetDamage(damage);
            Destroy(gameObject, 0.2f);
            Destroy(muzzle, 0.2f);

        }

        if (other.tag == "Police")
        {
            speed = 0;

            bullet.SetActive(false);
            muzzle.SetActive(true);
            fuckPolice = other.gameObject.GetComponent<FuckThePoliceBehaviour>();
            fuckPolice.GetDamage(damage/2);
            Destroy(gameObject, 0.2f);
        }

        if (other.tag == "Dron")
        {
            speed = 0;
            bullet.SetActive(false);
            muzzle.SetActive(true);
            dron = other.gameObject.GetComponent<DronBehaviour>();
            dron.GetDamage(damage / 2);
            Destroy(gameObject, 0.2f);
        }

        if (other.tag == "DestroyTorreta")
        {
            destroyTorreta = other.gameObject.GetComponent<DestroyTorreta>();
            destroyTorreta.GetDamage(damage/2);
            Destroy(gameObject);
        }

        if (other.tag == "Segurata")
        {
            segurata = other.gameObject.GetComponent<SegurataBehaviour>();
            segurata.Dead();
            Destroy(gameObject);
        }
        //Destroy(gameObject);

        if (other.tag == "PassilloPolice")
        {
            pPolice = other.gameObject.GetComponent<PassilloPolice>();
            pPolice.GetDamage(damage);
            Destroy(gameObject);
        }

        if (other.tag == "TallerPolice")
        {
            tallerPolice = other.gameObject.GetComponent<PoliceTaller>();
            tallerPolice.GetDamage(damage);
            Destroy(gameObject);
        }

        if (other.tag == "Barril")
        {
            barril = other.gameObject.GetComponent<BarrelExp>();
            barril.Explode();
            Destroy(gameObject);
        }

        if (other.tag == "Boss")
        {
            speed = 0;
            bullet.SetActive(false);
            muzzle.SetActive(true);
            boss = other.gameObject.GetComponent<BossBehaviour>();
            boss.GetDamage(damage);
            Destroy(gameObject, 0.2f);
        }
    }

    public void Level2()
    {
        damage = 2;
    }



}
