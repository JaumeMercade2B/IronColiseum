using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassilloPolice : MonoBehaviour
{

    public Renderer enemyRender;
    private Material dissolveMat;
    public bool dead;
    public float maxLife;
    public float life;

    private Transform player;
    private FPSController playerController;

    public float cadency;
    public float counter;

    public bool act;

    private ImprovementCell start;

    public float damage;
    private float restDamage;

    public float ammo;
    public float maxAmmo;
    public bool reloading;

    public float disolve;

    public Transform spawn;

    public LogicaPassadís logica;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        start = GameObject.FindGameObjectWithTag("InteractCell").GetComponent<ImprovementCell>();

        dissolveMat = enemyRender.material;

        life = maxLife;

        act = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (start.doorOpen == true)
        {

            counter += Time.deltaTime;
            transform.LookAt(player);

            Shoot();
        }

        if (life <= 0)
        {
            if (dead == false)
            {
                logica.enemyCounter++;
            }

            Dead();
        }

        
    }


    private void Shoot()
    {
        if (counter >= cadency && reloading == false && dead == false)
        {
            RaycastHit hit;

            if (Physics.Raycast(spawn.transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Player"))
                {
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
            }

            counter = 0;
            ammo--;

        }

        if (ammo <= 0)
        {
            ammo = 0;
            Reloading();
        }

    }


    private void Reloading()
    {
        StartCoroutine(WaitReload());
    }
    public void Disappear()
    {
        disolve += 0.5f * Time.deltaTime;
        dissolveMat.SetFloat("Vector1_283E90B", disolve);

    }

    private void OnDestroy()
    {
        Destroy(dissolveMat);
    }

    private void Dead()
    {

        dead = true;
        Disappear();
        

        if (disolve >= 1)
        {


            Destroy(gameObject, 0.5f);

        }
    }

    public void GetDamage(float damage)
    {
        life -= damage;
    }


    IEnumerator WaitReload()
    {
        reloading = true;
        ammo = maxAmmo;
        yield return new WaitForSeconds(2);
        reloading = false;
    }
}
