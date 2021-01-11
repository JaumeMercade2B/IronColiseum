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
    private FPSController player;

    public GameObject bullet;
    public GameObject muzzle;

    public Collider col;


    // Start is called before the first frame update
    void Start()
    {
        bullet.SetActive(true);
        muzzle.SetActive(false);

        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBehaviour>();
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

    }





}
