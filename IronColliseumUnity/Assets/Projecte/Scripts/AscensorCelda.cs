using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensorCelda : MonoBehaviour
{

    private Animator elevatorDoor;
    public bool isOpen;
    public bool isClosed;

    public Arma arma;

    public bool isCell;
    public bool isArena;

    public Animator transition;

    private FPSController player;
    private TeleportPlayer teleport;

    public AudioSource door;
    public AudioSource upSound;


    // Start is called before the first frame update
    void Start()
    {
        elevatorDoor = GameObject.FindGameObjectWithTag("ElevatorCell").GetComponent<Animator>();
        arma = GameObject.FindGameObjectWithTag("Arma").GetComponent<Arma>();
        teleport = GameObject.FindGameObjectWithTag("Player").GetComponent<TeleportPlayer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        isOpen = false;
        isCell = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (player.killedArena == false)
            {

                door.Play();
                elevatorDoor.SetBool("Open", true);
                elevatorDoor.SetBool("Close", false);

                isOpen = true;
                isClosed = false;
            }

            if (player.killedArena == true)
            {
                door.Play();

                elevatorDoor.SetBool("Close", true);
                elevatorDoor.SetBool("Open", false);

                isOpen = false;
                isClosed = true;
            }
            
            
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            if (player.killedArena == false)
            {
                door.Play();

                elevatorDoor.SetBool("Close", true);
                elevatorDoor.SetBool("Open", false);

                isClosed = true;
                isOpen = false;
            }
            
        }
        
    }

}
