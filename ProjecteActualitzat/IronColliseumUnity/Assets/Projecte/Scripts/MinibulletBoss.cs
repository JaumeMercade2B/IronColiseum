using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibulletBoss : MonoBehaviour
{
    public float damage;
    public float speed;

    public float range;
    public float rangeCounter;

    private BossBehaviour boss;
    private FPSController player;
    private Transform playerTrans;
    private Transform bossTrans;

    private float restDamage;

    private Rigidbody rb;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossBehaviour>();
        bossTrans = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();

        mainCamera = Camera.main;

        transform.forward = bossTrans.forward;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += transform.forward * speed * Time.deltaTime;
        //rb.AddForce(transform.forward * speed, ForceMode.Impulse);

        if (boss.isDead == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = FindObjectOfType<FPSController>();

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

