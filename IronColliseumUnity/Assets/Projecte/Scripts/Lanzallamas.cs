﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Lumin;
using Cinemachine;



public class Lanzallamas : MonoBehaviour
{
    public VisualEffect flamethrower;
    private ChangeWeapon change;

    public bool reloading;
    public bool canShoot;

    private GameManager manager;
    private HUD hud;
    private EnemyBehaviour enemy;
    private FuckThePoliceBehaviour fuckPolice;
    private DronBehaviour dron;

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

    private Camera mainCamera;
    public MouseLook mouseSens;
    public CinemachineVirtualCamera cam;

    //public Light fireLight;

    //private bool isShooting = false;

    public Material dissolveMat;
    public float disolve;

    public bool appear;
    public bool disappear;
    public bool hudAppear;

    void Start()
    {
        change = GameObject.FindGameObjectWithTag("Holder").GetComponent<ChangeWeapon>();
        SetActive();
        flamethrower.Stop();
        //fireLight.intensity += 0;
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        mainCamera = Camera.main;

        ammo = maxAmmo;
        hud.SetLanzallamasText(ammo, maxAmmo);

        
        disolve = 1;
        dissolveMat.SetFloat("Vector1_283E90B", disolve);

    }

    private void FixedUpdate()
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

                if (hit.transform.CompareTag("Police"))
                {
                    fuckPolice = hit.transform.GetComponent<FuckThePoliceBehaviour>();
                    fuckPolice.GetDamage(damage);
                    Debug.Log("hit");
                }

                if (hit.transform.CompareTag("Dron"))
                {
                    dron = hit.transform.GetComponent<DronBehaviour>();
                    dron.GetDamage(damage);
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

        if (appear == true)
        {
            reloading = true;
            disolve -= 0.8f * Time.deltaTime;
            dissolveMat.SetFloat("Vector1_283E90B", disolve);
            if (disolve <= 0)
            {
                disolve = 0;
                dissolveMat.SetFloat("Vector1_283E90B", disolve);
                hudAppear = true;
                reloading = false;
                appear = false;
            }
        }

        if (disappear == true)
        {
            reloading = true;
            disolve += 0.8f * Time.deltaTime;
            dissolveMat.SetFloat("Vector1_283E90B", disolve);

            if (disolve >= 1)
            {
                gameObject.SetActive(false);
            }

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
            mouseSens.mouseSensitivity = 8;
            canShoot = true;
            
        }

    }

    public void stopShot()
    {
        flamethrower.Stop();
        hold.Stop();
        stop.Stop();
        mouseSens.mouseSensitivity = 12;
        


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
            disappear = false;
            appear = true;
            gameObject.SetActive(true);
        }

        else if (change.ReturnCurrent() != 2)
        {
            disappear = true;
            hudAppear = false;
            
        }
    }

    public void Reload()
    {
        flamethrower.Stop();
        mouseSens.mouseSensitivity = 12;
        
        StopCoroutine(PointFOVIn());

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

    private IEnumerator PointFOVIn()
    {
        while (cam.m_Lens.FieldOfView < 18.1f)
        {
            cam.m_Lens.FieldOfView++;
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator PointFOVOut()
    {
        while (cam.m_Lens.FieldOfView > 18)
        {
            cam.m_Lens.FieldOfView--;
            yield return new WaitForEndOfFrame();
        }
    }


}
