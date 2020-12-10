﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeWeapon : MonoBehaviour
{

    public int currentWeapon = 0;
    //public HUD hud;
    private Arma arma;
    public Metralleta metralleta;
    public Lanzallamas lanzallamas;
    private GameManager manager;
    private bool canChange;

    [SerializeField] private float coolDown;
    [SerializeField] private float changeTrue = 1f;


    public bool hasMetralleta;
    public bool hasArma3;

    public bool hasChanged;

    // Start is called before the first frame update
    void Start()
    {
        hasChanged = false;

        //SelectWeapon();
        arma = GameObject.FindGameObjectWithTag("Arma").GetComponent<Arma>();
        metralleta = GameObject.FindGameObjectWithTag("Metralleta").GetComponent<Metralleta>();
        //arma3 = GameObject.FindGameObjectWithTag("Arma3").GetComponent<Arma3>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

        hasMetralleta = false;
        currentWeapon = 0;
        canChange = false;
        
        coolDown = changeTrue;

        arma.SetActive();
        //metralleta.SetActive();
        //arma3.SetActive();
    }

    // Update is called once per frame
    public void Update()
    {
        coolDown -= Time.deltaTime;


        if (hasMetralleta == true && hasArma3 == false && canChange)
        {

            coolDown = changeTrue;

            canChange = false;

            currentWeapon++;

            if (currentWeapon > 1)
            {
                currentWeapon = 0;
            }

            arma.SetActive();
            metralleta.SetActive();            

        }

        else if (hasMetralleta == true && hasArma3 == true && canChange)
        {

            coolDown = changeTrue;

            canChange = false;

            currentWeapon++;

            if (currentWeapon > 2)
            {
                currentWeapon = 0;
            }

            arma.SetActive();
            metralleta.SetActive();
            lanzallamas.SetActive();
        }

        else
        {
            return;
        }


    }

    //public void SelectWeapon()
    //{
    //    int i = 0;

    //    foreach (Transform weapon in transform)
    //    {
    //        if (i == currentWeapon)
    //        {
    //            weapon.gameObject.SetActive(true);
    //        }

    //        else
    //        {
    //            weapon.gameObject.SetActive(false);
    //        }

    //        i++;
    //    }
    //}

        public void Weapon()
    {

        if (hasMetralleta == true && coolDown <= 0 && metralleta.reloading == false && arma.reloading == false && manager.pause == false)
        {
            canChange = true;
            hasChanged = true;
        }
    }

    public int ReturnCurrent()
    {
        return (currentWeapon);
    }
}
