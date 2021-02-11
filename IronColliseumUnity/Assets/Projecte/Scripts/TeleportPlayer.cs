using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    public Transform spawnArena;
    public Transform spawnCell;
    public Transform spawnBoss;

    public Animator elevatorArena;
    public bool insideElevator;
    public Animator transition;
    public LevelManager levelManager;
    private FPSController player;
    public Animator ascensorCelda;
    private ElevatorArena elevator;

    public AudioSource elevatorDoor;

 

    // Start is called before the first frame update
    void Start()
    {
        insideElevator = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        elevator = GameObject.FindGameObjectWithTag("ElevatorArena").GetComponent<ElevatorArena>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TeleportArena()
    {

        
        //levelManager.alreadyInstanciate = true;
        if (insideElevator == true && player.killedArena == false)
        {
            levelManager.InstantiateArena();

            StartCoroutine(WaitTeleport());
        }

        if (insideElevator == true && player.killedArena == true)
        {
            ascensorCelda.SetBool("Open", true);
            ascensorCelda.SetBool("Close", false);

        }
    }

    public void TeleportCell()
    {

        //levelManager.alreadyInstanciate = true;
        if (player.killedArena == true)
        {

            StartCoroutine(WaitTeleportCell());
        }
    }

    public void TeleportBoss()
    {
        StopAllCoroutines();
        StartCoroutine(WaitTeleportBoss());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InsideElevator")
        {
            
            insideElevator = true;
            TeleportArena();
        }

        if (other.tag == "InsideArena")
        {
            TeleportCell();
        }
    }

    IEnumerator WaitTeleport()
    {
        transition.SetTrigger("Start");
        elevatorDoor.Play();
        yield return new WaitForSeconds(4f);
        transform.position = spawnArena.transform.position;
        elevator.DoorSound();
        insideElevator = false;
        transition.SetTrigger("End");


    }

    IEnumerator WaitTeleportCell()
    {
        
        elevatorArena.SetBool("Close", true);
        elevatorArena.SetBool("Open", false);

        yield return new WaitForSeconds(0.2f);

        transition.SetTrigger("Start");
        elevatorDoor.Play();

        yield return new WaitForSeconds(4f);
        transform.position = spawnCell.transform.position;
        transition.SetTrigger("End");
        elevator.RestartEnemyElevator();

    }

    IEnumerator WaitTeleportBoss()
    {
        elevator.Down();
        levelManager.InstantiateBoss();
        yield return new WaitForSeconds(0.5f);
        //transition.SetTrigger("Start");
        yield return new WaitForSeconds(4f);
        transform.position = spawnBoss.transform.position;
        //transition.SetTrigger("End");


    }
}
