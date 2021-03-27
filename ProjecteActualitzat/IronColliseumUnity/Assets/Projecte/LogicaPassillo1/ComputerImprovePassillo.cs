using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerImprovePassillo : MonoBehaviour
{
    public Metralleta metralleta;
    private BulletBehaviour bullet;
    public Arma plasma;
    public Lanzallamas lanza;
    private FPSController player;

    private GameManager manager;

    public Button improvePlasma;
    public Button improveMetralleta;
    public Button improveLanza;
    public Button improveLife;
    public Button improveShield;




    public float pricePlasma;
    public float priceMetralleta;
    public float priceLanza;
    public float priceLife;
    public float priceShield;
    public float priceLife2;
    public float priceShield2;

    public GameObject textPricingLife1;
    public GameObject textPricingLife2;

    public GameObject textPricingShield1;
    public GameObject textPricingShield2;

    public DoorToTaller door;

    public GameObject cellComp;

    



    private HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        //metralleta = GameObject.FindGameObjectWithTag("Metralleta").GetComponent<Metralleta>();
        //plasma = GameObject.FindGameObjectWithTag("Arma").GetComponent<Arma>();
        //lanza = GameObject.FindGameObjectWithTag("Lanzallamas").GetComponent<Lanzallamas>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();


    }

    // Update is called once per frame
    void Update()
    {
        if (player.lifeLevel2 == false)
        {
            textPricingLife1.SetActive(true);
            textPricingLife2.SetActive(false);
        }

        else if (player.lifeLevel2 == true)
        {
            textPricingLife1.SetActive(false);
            textPricingLife2.SetActive(true);
        }

        if (player.shieldLevel2 == false)
        {
            textPricingShield1.SetActive(true);
            textPricingShield2.SetActive(false);
        }

        else if (player.shieldLevel2 == true)
        {
            textPricingShield1.SetActive(false);
            textPricingShield2.SetActive(true);
        }


        if (player.tuercas < pricePlasma && plasma.level2 == false)
        {
            improvePlasma.interactable = false;
        }

        else
        {
            improvePlasma.interactable = true;

        }

        if (player.tuercas < priceMetralleta && metralleta.level2 == false)
        {
            improveMetralleta.interactable = false;
        }

        else
        {
            improveMetralleta.interactable = true;

        }

        if (player.tuercas < priceLanza)
        {
            improveLanza.interactable = false;
        }

        else
        {
            improveLanza.interactable = true;

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

        if (player.lifeLevel2 == false)
        {
            player.LiveLevel2();

            improveLife.interactable = false;

            player.tuercas -= priceLife;
            hud.SetTuercas(player.tuercas);
        }

        else if (player.lifeLevel2 == true)
        {
            player.LiveLevel3();

            improveLife.interactable = false;

            player.tuercas -= priceLife2;
            hud.SetTuercas(player.tuercas);
        }




    }

    public void ImproveShield()
    {
        if (player.shieldLevel2 == false)
        {
            player.ShieldLevel2();

            improveShield.interactable = false;

            player.tuercas -= priceShield2;
            hud.SetTuercas(player.tuercas);
        }

        else if (player.shieldLevel2 == true)
        {
            player.ShieldLevel3();

            improveShield.interactable = false;

            player.tuercas -= priceShield;
            hud.SetTuercas(player.tuercas);
        }


    }

    public void OpenDoor()
    {
        door.Open();
        Time.timeScale = 1;
        manager.openMenu = false;
        hud.ClosePassilloComputer();
    }
}
