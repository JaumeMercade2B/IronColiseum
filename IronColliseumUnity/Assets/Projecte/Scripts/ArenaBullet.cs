using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaBullet : MonoBehaviour
{
    public float speed = 30f;
    private float range;
    public float maxRange;
    public float damage = 0.2f;
    public float restDamage = 0f;

    private Transform target;
    private float distance;
    private Vector3 targetPos;
    private float time;
    //public GameObject explosionPrefab;


    private EnemyBehaviour enemy;
    private FPSController player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FPSController>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetPos = target.transform.position;
        distance = Vector3.Distance(transform.position, targetPos);
    }

    // Update is called once per frame
    virtual public void Update()
    {

       
        transform.position += transform.forward * speed * Time.deltaTime;
        //transform.LookAt(player.finalPos);

        range += Time.deltaTime;

        if (range >= maxRange)
        {
            Destroy(gameObject);
        }

        time = distance / speed;
        player.predictionTime = time;
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

        if (other.tag == "Player")
        {
            


            //player.GetDamage(damage);


            //if (player.shield > 0)
            //{
            //    player.ShieldDamage(damage);
            //}


            if (player.shield > damage)
            {
                player.ShieldDamage(damage);
            }
            else if (player.shield <= damage && player.shield > 0)
            {
                restDamage = damage - player.shield;
                player.GetDamage(restDamage);
                player.shield = 0;
                restDamage = 0;
            }

            else if (player.shield <= 0)
            {
                player.GetDamage(damage);
            }

            Destroy(gameObject);

        }

    }



}
