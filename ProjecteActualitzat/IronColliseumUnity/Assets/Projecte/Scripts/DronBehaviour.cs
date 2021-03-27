using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronBehaviour : MonoBehaviour
{

    public float life;
    public float maxLife;


    private Material dissolveMat;
    private Material dissolveMat2;
    private Material dissolveMat3;


    public float disolve;

    public bool dead;

    public GameObject exp;

    public Renderer renderDron;
    public Renderer renderHelix;
    public Renderer renderHelix2;

    private LogicaTaller logica;


    //public Transform expInst;

    // Start is called before the first frame update
    void Start()
    {
        logica = GameObject.FindGameObjectWithTag("LogicaTaller").GetComponent<LogicaTaller>();

        maxLife = 1;
        life = maxLife;
        dissolveMat = renderDron.material;
        dissolveMat2 = renderHelix.material;
        dissolveMat3 = renderHelix2.material;

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

            if (dead == false)
            {
                logica.deadEnemies++;
            }
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

    

            
        Destroy(gameObject, 1f);

        
    }

    public void Appear()
    {
        disolve -= 0.3f * Time.deltaTime;
    }

    public void Disappear()
    {
        disolve += 0.5f * Time.deltaTime;

    }

    private void OnDestroy()
    {
        Destroy(dissolveMat);
        Destroy(dissolveMat2);
        Destroy(dissolveMat3);

    }
}
