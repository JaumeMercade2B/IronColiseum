using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorArena : MonoBehaviour
{

    public Animator elevatorDoor;
    public Animator transition;
    private Animator upDown;
    public Animator enemyDoor;
    public Animator enemyElevator;
    public Arma arma;
    public Mele mele;

    public bool isOpen;
    public bool isClosed;

    public LevelManager levelManager;

    private FPSController player;

    public AudioSource door;
    //public AudioSource down;

    private OleadasTalller oleadas;


    // Start is called before the first frame update
    void Start()
    {
        //elevatorDoor = GetComponentInChildren<Animator>();
        upDown = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        oleadas = GameObject.FindGameObjectWithTag("SpawnPolice").GetComponent<OleadasTalller>();
       
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.killedArena == true)
        {
            StopCoroutine(GoDown());
            Up();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && isOpen == false && player.killedArena == false)
        {
            StartCoroutine(OpenDoor());
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && isClosed == false && player.killedArena == false)
        {
            //door.Play();
            elevatorDoor.SetBool("Close", true);
            elevatorDoor.SetBool("Open", false);

            enemyDoor.SetTrigger("Close");
            isClosed = true;
        }
        isOpen = false;
    }

    public void Down()
    {

            StartCoroutine(GoDown());    
    }

    public void Up()
    {
        
            
        upDown.SetBool("Up", true);
        upDown.SetBool("Down", false);
        StartCoroutine(OpenDoor());


    }

    public void RestartEnemyElevator()
    {
        enemyDoor.SetTrigger("Open");
        enemyElevator.SetTrigger("Restart");
    }

    public void DoorSound()
    {
        door.Play();
    }

    IEnumerator OpenDoor()
    {
        //down.Play();

        yield return new WaitForSeconds(1f);
        //door.Play();
        elevatorDoor.SetBool("Open", true);
        elevatorDoor.SetBool("Close", false);
        yield return new WaitForSeconds(0.5f);
        //elevatorDoor.SetBool("Open", false);
        //elevatorDoor.SetBool("Close", false);
        //down.Stop();
        StopCoroutine(OpenDoor());

        //isOpen = true;

    }

    IEnumerator GoDown()
    {

       
        yield return new WaitForSeconds(1.5f);
        //down.Play();

        upDown.SetBool("Down", true);
        upDown.SetBool("Up", false);

        enemyElevator.SetTrigger("Down");
        arma.hasWeapon = true;
        mele.hasWeapon = true;
        yield return new WaitForSeconds(1.5f);
        levelManager.startArena = true;
        //down.Stop();
    }

    
}
