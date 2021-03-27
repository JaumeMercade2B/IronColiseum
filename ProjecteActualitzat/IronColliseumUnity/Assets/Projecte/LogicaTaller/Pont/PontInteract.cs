using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PontInteract : MonoBehaviour
{
    public GameObject gamepadSprite;
    public GameObject keyboardSprite;

    public GameObject timeline;

    public DetectInput input;

    public bool canInteract;

    private LevelManager levelManager;

    private Collider col;


    // Start is called before the first frame update
    void Start()
    {

        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        col = GetComponent<Collider>();
        col.enabled = true;


        canInteract = false;
        timeline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (canInteract)
        {
            if (input.gamepadActive == false)
            {
                Keyboard kb = InputSystem.GetDevice<Keyboard>();

                if (kb.gKey.isPressed)
                {

                    StartCoroutine(Timeline());
                }
            }

            if (input.gamepadActive == true)
            {
                Gamepad Gp = InputSystem.GetDevice<Gamepad>();

                if (Gp.dpad.down.isPressed)
                {
                    StartCoroutine(Timeline());
                }
            }
        }
       
    }

    public void OnTriggerStay(Collider other)
    {
        canInteract = true;

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
            canInteract = false;

            keyboardSprite.SetActive(false);
            gamepadSprite.SetActive(false);
        }
    }

    private IEnumerator Timeline()
    {
        
        col.enabled = false;
        keyboardSprite.SetActive(false);
        gamepadSprite.SetActive(false);
        levelManager.canAct = false;
        timeline.SetActive(true);
        yield return new WaitForSeconds(6.5f);
        
        levelManager.canAct = true;
        timeline.SetActive(false);
    }
}
