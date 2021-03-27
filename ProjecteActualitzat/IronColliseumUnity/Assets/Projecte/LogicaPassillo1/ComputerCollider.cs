using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ComputerCollider : MonoBehaviour
{

    public GameObject keyboardSprite;
    public GameObject gamepadSprite;

    public DetectInput input;

    public GameObject canvasComputer;

    private FPSController player;

    private GameManager manager;
    private HUD hud;

    


    // Start is called before the first frame update
    void Start()
    {
        keyboardSprite.SetActive(false);
        gamepadSprite.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Keyboard kb = InputSystem.GetDevice<Keyboard>();

            if (input.gamepadActive == false)
            {
                keyboardSprite.SetActive(true);
                gamepadSprite.SetActive(false);

                if (kb.gKey.isPressed)
                {
                    Time.timeScale = 0;

                    manager.openMenu = true;

                    hud.OpenPassilloComputer();
                }
            }

            if (input.gamepadActive == true)
            {

                Gamepad Gp = InputSystem.GetDevice<Gamepad>();

                keyboardSprite.SetActive(false);
                gamepadSprite.SetActive(true);

                if (Gp.dpad.down.isPressed)
                {
                    Time.timeScale = 0;

                    hud.OpenPassilloComputer();

                }
            }


        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            keyboardSprite.SetActive(false);
            gamepadSprite.SetActive(false);
        }
    }
}
