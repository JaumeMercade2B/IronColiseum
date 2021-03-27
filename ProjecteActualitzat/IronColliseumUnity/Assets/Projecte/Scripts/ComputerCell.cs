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

    private HUD hud;

    private GameManager manager;

    private FPSController player;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        col.enabled = false;

        //keyboardSprite.SetActive(false);
        //gamepadSprite.SetActive(false);

        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();



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
                    //doorTaller.Open();

                    hud.OpenCellComputer();

                    animator.SetBool("OpenDoor", false);
                    animator.SetBool("CloseDoor", false);
                    animator.SetBool("OpenComputer", true);
                    animator.SetBool("CloseComputer", false);

                    Time.timeScale = 0;

                    keyboardSprite.SetActive(false);
                    gamepadSprite.SetActive(false);
                    //manager.UnlockCursor();
                    manager.openMenu = true;
                    player.tuercasUI.SetActive(true);

                }
            }

            if (input.gamepadActive == true)
            {
                Gamepad Gp = InputSystem.GetDevice<Gamepad>();

                if (Gp.dpad.down.isPressed)
                {
                    //doorTaller.Open();
                    hud.OpenCellComputer();

                    animator.SetBool("OpenDoor", false);
                    animator.SetBool("CloseDoor", false);
                    animator.SetBool("OpenComputer", true);
                    animator.SetBool("CloseComputer", false);

                    Time.timeScale = 0;

                    keyboardSprite.SetActive(false);
                    gamepadSprite.SetActive(false);
                    //manager.UnlockCursor();
                    manager.openMenu = true;
                    player.tuercasUI.SetActive(true);



                }
            }
        }


    }
    public void Close()
    {
        animator.SetBool("OpenDoor", false);
        animator.SetBool("CloseDoor", false);
        animator.SetBool("OpenComputer", false);
        animator.SetBool("CloseComputer", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
            animator.SetBool("OpenDoor", true);
            animator.SetBool("CloseDoor", false);
            animator.SetBool("OpenComputer", false);
            animator.SetBool("CloseComputer", false);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        

        if (other.tag == "Player")
        {


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
            animator.SetBool("CloseDoor", true);
            animator.SetBool("OpenDoor", false);
            animator.SetBool("OpenComputer", false);
            animator.SetBool("CloseComputer", false);



            keyboardSprite.SetActive(false);
            gamepadSprite.SetActive(false);
        }
    }
}
