using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ComputerCell : MonoBehaviour
{

    private Collider col;

    public GameObject gamepadSprite;
    public GameObject keyboardSprite;

    public DetectInput input;

    public bool canOpen;

    public TallerDoor doorTaller;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        col.enabled = false;

        keyboardSprite.SetActive(false);
        gamepadSprite.SetActive(false);

        canOpen = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen == true)
        {
            if (input.gamepadActive == false)
            {
                Keyboard kb = InputSystem.GetDevice<Keyboard>();

                if (kb.gKey.isPressed)
                {
                    doorTaller.Open();
                }
            }

            if (input.gamepadActive == true)
            {
                Gamepad Gp = InputSystem.GetDevice<Gamepad>();

                if (Gp.dpad.down.isPressed)
                {
                    doorTaller.Open();

                }
            }
        }


    }

    private void OnTriggerStay(Collider other)
    {
        

        if (other.tag == "Player")
        {
            canOpen = true;

            if (input.gamepadActive == false)
            {
                
                keyboardSprite.SetActive(true);
                gamepadSprite.SetActive(false);
            }

            if (input.gamepadActive == true)
            {
                
                keyboardSprite.SetActive(false);
                gamepadSprite.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;

            keyboardSprite.SetActive(false);
            gamepadSprite.SetActive(false);
        }
    }
}
