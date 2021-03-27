using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialAttack : MonoBehaviour
{
    [SerializeField] float speed;
    private Transform scale;
    private float scaleX;
    private float scaleY;

    public float duration;
    public float durationCounter;

    private FPSController player;
    private float restDamage;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        scale = GetComponent<Transform>();

        speed = Random.Range(4f, 8f);
        duration = Random.Range(4f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        durationCounter += Time.deltaTime;
        //scaleX = scale.transform.localScale.x;
        //scaleY = scale.transform.localScale.y;

        //scaleX += speed * Time.deltaTime;
        //scaleY += speed * Time.deltaTime;

        transform.localScale += new Vector3(1f, 0.05f, 1f) * speed * Time.deltaTime;

        if (durationCounter >= duration)
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
