using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{

    public float damage;
    public float restDamage;

    public bool didDamage;
    private FPSController player;

    // Start is called before the first frame update
    void Start()
    {
        didDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.transform.GetComponent<FPSController>();


            if (didDamage == false)
            {
                if (player.shield > damage)
                {
                    player.ShieldDamage(damage);
                    didDamage = true;
                }
                else if (player.shield <= damage && player.shield > 0)
                {
                    restDamage = damage - player.shield;
                    player.GetDamage(restDamage);
                    player.shield = 0;
                    restDamage = 0;
                    didDamage = true;
                }

                else if (player.shield <= 0)
                {
                    player.GetDamage(damage);
                    didDamage = true;
                }
            }


        }
    }
}
