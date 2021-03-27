using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImprovementCell : MonoBehaviour
{
    private Metralleta metralleta;
    private BulletBehaviour bullet;
    private Arma plasma;
    private FPSController player;
    private TallerDoor door;
    private HUD hud;
    private GameManager manager;

    public Button improvePlasma;
    public Button improveMetralleta;
    public Button improveLife;
    public Button improveShield;

    public bool bulletImprove;
    public bool doorOpen;


    public float pricePlasma;
    public float priceMetralleta;
    public float priceLife;
    public float priceShield;

    private ComputerCell comp;

    public GameObject lights;
    public GameObject redLights;


    // Start is called before the first frame update
    void Start()
    {

        metralleta = GameObject.FindGameObjectWithTag("Metralleta").GetComponent<Metralleta>();
        //bullet = GameObject.FindGameObjectWithTag("PlasmaBullet").GetComponent<BulletBehaviour>();
        plasma = GameObject.FindGameObjectWithTag("Arma").GetComponent<Arma>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        door = GameObject.FindGameObjectWithTag("TallerDoor").GetComponent<TallerDoor>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        comp = GameObject.FindGameObjectWithTag("ComputerCell").GetComponent<ComputerCell>();


        bulletImprove = false;
        redLights.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (player.tuercas < pricePlasma)
        {
            improvePlasma.interactable = false;
        }

        else
        {
            improvePlasma.interactable = true;

        }

        if (player.tuercas < priceMetralleta)
        {
            improveMetralleta.interactable = false;
        }

        else
        {
            improveMetralleta.interactable = true;

        }

        if (player.tuercas < priceLife)
        {
            improveLife.interactable = false;
        }

        else
        {
            improveLife.interactable = true;

        }

        if (player.tuercas < priceShield)
        {
            improveShield.interactable = false;
        }

        else
        {
            improveShield.interactable = true;

        }
    }

    public void ImprovePlasma()
    {

        plasma.Level2();
        //bullet.Level2();
        //bulletImprove = true;
        improvePlasma.interactable = false;

        player.tuercas -= pricePlasma;
        hud.SetTuercas(player.tuercas);
    }
    public void ImproveMetralleta()
    {
        metralleta.Level2();
   

        improveMetralleta.interactable = false;

        player.tuercas -= priceMetralleta;
        hud.SetTuercas(player.tuercas);

    }

    public void ImproveLife()
    {

        player.LiveLevel2();

        improveLife.interactable = false;

        player.tuercas -= priceLife;
        hud.SetTuercas(player.tuercas);


    }

    public void ImproveShield()
    {

        player.ShieldLevel2();

        improveShield.interactable = false;

        player.tuercas -= priceShield;
        hud.SetTuercas(player.tuercas);

    }

    public void OpenDoor()
    {
        lights.SetActive(false);
        redLights.SetActive(true);
        doorOpen = true;
        comp.Close();
        door.Open();
        hud.CloseCellComputer();
        manager.openMenu = false;
        player.tuercasUI.SetActive(false);
        Time.timeScale = 1;
    }

}
