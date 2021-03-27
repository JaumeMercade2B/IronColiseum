using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{

    public float speed = 30f;

    public float life;
    public float lifeCounter;

    public float damage;

    public GameObject splitBullet;
    public Transform split1;
    public Transform split2;
    public Transform split3;

    private FPSController player;

    private Transform boss;
    private BossBehaviour bossLife;

    private float restDamage;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
        bossLife = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossBehaviour>();


        life = Random.Range(0.3f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        lifeCounter += Time.deltaTime;

        transform.forward = boss.forward;
        transform.position += transform.forward * speed * Time.deltaTime;

        if (bossLife.isDead == true)
        {
            Destroy(gameObject);
        }

        if (lifeCounter >= life)
        {
            Split();
        }
    }


    public void Split()
    {
        Instantiate(splitBullet, split1.transform.position, Quaternion.identity);
        Instantiate(splitBullet, split2.transform.position, Quaternion.identity);
        Instantiate(splitBullet, split3.transform.position, Quaternion.identity);

        Destroy(gameObject);

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
        }
    }
}
