using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronBehaviour : MonoBehaviour
{

    public float life;
    public float maxLife;


    public Material dissolveMat;
    public float disolve;

    public bool dead;

    public GameObject exp;

    //public Transform expInst;

    // Start is called before the first frame update
    void Start()
    {
        maxLife = 1;
        life = maxLife;

        disolve = 1;
        dissolveMat.SetFloat("Vector1_283E90B", disolve);
        dead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dead == false)
        {
            if (disolve >= 0)
            {
                disolve -= 0.5f * Time.deltaTime;
                dissolveMat.SetFloat("Vector1_283E90B", disolve);

            }

            if (disolve <= 0)
            {
                disolve = 0;
                dissolveMat.SetFloat("Vector1_283E90B", disolve);

            }
        }

        if (life <= 0)
        {
            Dead();

        }
    }

    public void GetDamage(float damage)
    {
        life -= damage;
    }

    private void Dead()
    {
        dead = true;
        Disappear();
        dissolveMat.SetFloat("Vector1_283E90B", disolve);
        //Instantiate(exp, transform.position, Quaternion.identity);

        if (disolve == 1)
        {

            
            Destroy(gameObject, 1f);

        }
    }

    public void Appear()
    {
        disolve -= 0.3f * Time.deltaTime;
    }

    public void Disappear()
    {
        disolve += 0.5f * Time.deltaTime;

    }
}
