using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Lumin;


public class Lanzallamas : MonoBehaviour
{
    public VisualEffect flamethrower;
    private ChangeWeapon change;

    public bool reloading;
    public bool canShoot;

    private GameManager manager;
    private HUD hud;
    private EnemyBehaviour enemy;
    private FPSController player;


    public float maxAmmo = 20f;
    public float ammo;
    public float reloadTime = 4f;
    public float damage = 0.2f;
    public float distance = 50;
    public Transform spawn;
    public bool justReloaded;

    public AudioSource hold;
    public AudioSource stop;

    //public Light fireLight;

    //private bool isShooting = false;

    void Start()
    {
        change = GameObject.FindGameObjectWithTag("Holder").GetComponent<ChangeWeapon>();
        SetActive();
        flamethrower.Stop();
        //fireLight.intensity += 0;
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();

        ammo = maxAmmo;
        hud.SetLanzallamasText(ammo, maxAmmo);
    }

    private void Update()
    {
        if (canShoot)
        {

            flamethrower.Play();
            justReloaded = false;
            RaycastHit hit;


            if (Physics.Raycast(spawn.transform.position, spawn.transform.forward, out hit, distance)) //Aquí diem si el raig ha xocat amb quelcom
            {

                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("Enemy"))
                {
                    enemy = hit.transform.GetComponent<EnemyBehaviour>();
                    enemy.GetDamage(damage);
                    Debug.Log("hit");
                }
            }

            if (player.godMode == false)
            {
                ammo--;
            }

            hud.SetLanzallamasText(ammo, maxAmmo);

        }

        if (ammo <= 0)
        {
            ammo = 0;
            Reload();
        }
    }

    public void Shot()
    {
        stop.Stop();
        if (reloading || manager.pause == true || player.isDead == true)
        {
            return;
        }

        if (ammo <= 0)
        {
            flamethrower.Stop();
            hold.Stop();
            canShoot = false;
            Reload();
            return;
        }

        if (ammo > 0 && player.isDead == false)
        {
            hold.Play();
            canShoot = true;
            
        }
 
    }

    public void stopShot()
    {
        flamethrower.Stop();
        hold.Stop();
        stop.Stop();

        if (manager.pause == false && justReloaded == false && reloading == false)
        {
            stop.Play();

        }

        canShoot = false;
        //isShooting = false;
        //if (!isShooting)
        //{
        //    fireLight.intensity -= 50000;
        //}
    }

    public void SetActive()
    {
        if (change.ReturnCurrent() == 2)
        {
            gameObject.SetActive(true);
        }

        else if (change.ReturnCurrent() != 2)
        {
            gameObject.SetActive(false);
        }
    }

    public void Reload()
    {
        flamethrower.Stop();

        if (reloading || ammo == maxAmmo || manager.pause == true)
        {
            return;
        }

        reloading = true;
        StartCoroutine(WaitForReload());
    }

    IEnumerator WaitForReload()
    {
        hold.Stop();
        stop.Play();
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;
        hud.SetLanzallamasText(ammo, maxAmmo);
        reloading = false;
        hold.Stop();
        justReloaded = true;
        //canShoot = true;

    }



}
