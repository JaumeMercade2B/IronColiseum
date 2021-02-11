using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDoor : MonoBehaviour
{

    private Animator door;
    public Collider col;

    public bool isOpen;
    public bool isClosed;

    private FPSController player;

    public AudioSource doorSound;


    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("CelDoor").GetComponent<Animator>();
        //door.SetTrigger("StayClose");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Player")
        {
            //if (player.killedArena == false)
            //{
            doorSound.Play();
                door.SetBool("Open", true);
                door.SetBool("Close", false);

                isOpen = true;
                isClosed = false;
           // }

            //if (player.killedArena == true)
            //{
            //    door.SetBool("Close", false);
            //    door.SetBool("Open", true);
            //    isOpen = false;
            //    isClosed = true;
            //}
            
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
        {

            //if(player.killedArena == false)
            //{
            doorSound.Play();

            door.SetBool("Close", true);
                door.SetBool("Open", false);
            //}

            //if (player.killedArena == true)
            //{
            //    door.SetBool("Close", false);
            //    door.SetBool("Open", true);
            //}
            

            isClosed = true;
        }

        isOpen = false;
    }

    
}
