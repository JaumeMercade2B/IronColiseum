using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject inventoryPanel;

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI metralletaText;
    public TextMeshProUGUI lanzaText;

    public GameObject hudArma;
    public GameObject hudMetralleta;
    public GameObject hudLanza;

    private ChangeWeapon change;
    public Slider playerLife;
    public Image leftDash;
    public Image misil;
    public Image shield;



    public TextMeshProUGUI tuercasText;
    private FPSController FPScontroller;

    public Image misilUI;

    public Lanzallamas lanza;
    public Arma plasma;
    public Metralleta metralleta;


    public void Awake()
    {
        FPScontroller = FindObjectOfType<FPSController>();

        change = GameObject.FindGameObjectWithTag("Holder").GetComponent<ChangeWeapon>();
        
    }

    public void Update()
    {
        if (change.ReturnCurrent() == 0 && plasma.hudAppear == true)
        {
            hudArma.SetActive(true);
        }

        else if (change.ReturnCurrent() != 0 || plasma.hudAppear == false)
        {
            hudArma.SetActive(false);
        }

        if (change.ReturnCurrent() == 1)
        {
            hudMetralleta.SetActive(true);
        }

        else if (change.ReturnCurrent() != 1)
        {
            hudMetralleta.SetActive(false);
        }

        if (change.ReturnCurrent() == 2 && lanza.hudAppear == true)
        {
            hudLanza.SetActive(true);
        }

        else if (change.ReturnCurrent() != 2 || lanza.hudAppear == false)
        {
            hudLanza.SetActive(false);
        }

        SetTuercas(FPScontroller.tuercas);

        shield.fillAmount = CalculateShield();
    }
    public void SetAmmoText(float ammo)
    {

        ammoText.text = ammo.ToString(); 

    }

    public void SetMetralletaText(float ammo, float maxAmmo)
    {
        metralletaText.text = ammo.ToString() + " - " + maxAmmo.ToString(); ;
    }

    public void SetLanzallamasText(float ammo, float maxAmmo)
    {
        lanzaText.text = ammo.ToString() + " - " + maxAmmo.ToString(); ;
    }


    public void SetTuercas(float tuercas)
    {

        tuercasText.text = tuercas.ToString();

    }

    public void OpenPausePanel(bool pause)
    {
        pausePanel.SetActive(pause);
    }

    public void OpenInventoryPanel(bool inventory)
    {
        inventoryPanel.SetActive(inventory);
    }

    public void AlphaMisilNormal()
    {
        Color c = misil.color;
        c.a = 0.8f;
        misil.color = c;
    }

    public void AlphaMisilTransp()
    {
        Color c = misil.color;
        c.a = 0.4f;
        misil.color = c;
    }

    public float CalculateMisil()
    {

        if(FPScontroller.misilCounter == FPScontroller.misilCadency)
        {
            FPScontroller.misilCounter = FPScontroller.misilCadency;
        }

        return FPScontroller.misilCounter / FPScontroller.misilCadency;
    }

    public float CalculateShield()
    {
        return FPScontroller.shield / FPScontroller.maxShield;
    }
}
