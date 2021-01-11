using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class Metralleta : MonoBehaviour
{

    public VisualEffect muzzleFlash;
    public VisualEffect enemyHit;
    public VisualEffect hitNoDecal;

    public bool canShoot = true;

    public int maxAmmo = 30;
    public int ammo;

    public float reloadTime = 0.5f;
    public bool reloading;

    public float damage = 1;
    public float cadency = 0;
    public float waitCadency= 0.01f;

    public float distance = 50;

    public Transform spawn;

    public Camera mainCamera;

    private GameManager manager;

    private ChangeWeapon change;

    private EnemyBehaviour enemy;

    private FuckThePoliceBehaviour fuckPolice;

    private DronBehaviour dron;

    private HUD hud;

    private FPSController player;


    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = Camera.main;
        canShoot = false;
        ammo = maxAmmo;
        cadency = 0.2f;

        muzzleFlash.Stop();

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        change = GameObject.FindGameObjectWithTag("Holder").GetComponent<ChangeWeapon>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();

        //automatic = GameObject.FindGameObjectWithTag("Automatic").GetComponent<Automatic>();

        hud.SetMetralletaText(ammo, maxAmmo);
    }

    public void Update()
    {
        SetActive();
        Debug.DrawRay(spawn.transform.position, spawn.transform.forward * distance, Color.green);

        if (canShoot && cadency >= waitCadency)
        {


            muzzleFlash.Play();
            //Ray ray = mainCamera.ScreenPointToRay(screenPos);


            //cadency = 0;


            //automatic.SetActive();

            //Ray ray = mainCamera.ScreenPointToRay(mainCamera.transform.forward);
            RaycastHit hit;

            //for (int i = 0; i <= ammo; i++)
            //{

                if (Physics.Raycast(spawn.transform.position, spawn.transform.forward, out hit, distance)) //Aquí diem si el raig ha xocat amb quelcom
                {

                    Debug.Log(hit.transform.name);
                    if (hit.transform.CompareTag("Enemy"))
                    {
                        enemy =  hit.transform.GetComponent<EnemyBehaviour>();
                        enemy.GetDamage(damage);
                    //enemyHit.Play(hit.transform)
                    //enemyHit.transform.position = 
                    //enemyHit.Play();
                    Destroy(enemyHit, 1f);
                        
                        Debug.Log("hit");
                    }

                if (hit.transform.CompareTag("Police"))
                {
                    fuckPolice = hit.transform.GetComponent<FuckThePoliceBehaviour>();
                    fuckPolice.GetDamage(damage);
                    //enemyHit.Play(hit.transform)
                    //enemyHit.transform.position = 
                    //enemyHit.Play();
                    Destroy(enemyHit, 1f);

                    Debug.Log("hit");
                }

                if (hit.transform.CompareTag("Dron"))
                {
                    dron = hit.transform.GetComponent<DronBehaviour>();
                    dron.GetDamage(damage);
                    //enemyHit.Play(hit.transform)
                    //enemyHit.transform.position = 
                    //enemyHit.Play();
                    Destroy(enemyHit, 1f);

                    Debug.Log("hit");
                }


            }
            //}

            //Debug.Log("Shoot");
            if (player.godMode == false)
            {
                ammo--;
            }
            
            hud.SetMetralletaText(ammo, maxAmmo);
            cadency = 0;
        }

        if (ammo <= 0)
        {
            ammo = 0;
            Reload();
        }

        //if (!canShoot)
        //{
        //    automatic.SetInactive();

        //}
    }
    public void FixedUpdate()
    {
        cadency += Time.deltaTime;
    }

    // Update is called once per frame
    public void OnShoot()
    {
        

         
        
    }

    public void Shoot()
    {

        if (reloading || manager.pause == true || player.isDead == true)
        {
            return;
        }

        if (ammo <= 0)
        {
            canShoot = false;
            Reload();
            return;
        }

        if (player.isDead == false)
        {
            canShoot = true;

        }


    }

    public void StopShoot()
    {
        canShoot = false;
    }

    public void Reload()
    {
        if (reloading || ammo == maxAmmo || manager.pause == true)
        {
            return;
        }

        reloading = true;
        StartCoroutine(WaitForReload());
    }

    public void SetActive()
    {
        if (change.ReturnCurrent() == 1)
        {
            gameObject.SetActive(true);
        }

        else if (change.ReturnCurrent() != 1)
        {
            gameObject.SetActive(false);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
        
    //}

    IEnumerator WaitForReload()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;
        hud.SetMetralletaText(ammo, maxAmmo);
        reloading = false;
        //canShoot = true;
   
    }

    //IEnumerator WaitForCadency() //La pots cridar cada x temps, el que tu vulguis
    //{
    //    canShoot = false;
    //    yield return new WaitForSeconds(cadency); //Quant temps espera per passar a la seguent linea. Es un corrutina
    //    canShoot = true;
    //}

}