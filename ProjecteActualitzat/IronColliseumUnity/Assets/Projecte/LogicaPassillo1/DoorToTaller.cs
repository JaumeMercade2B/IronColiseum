using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToTaller : MonoBehaviour
{
    public Animator leftDoor;
    public Animator rightDoor;

    public Collider col;

    public AudioSource door;
    private FPSController player;


    // Start is called before the first frame update
    void Start()
    {
        col.enabled = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        leftDoor.SetBool("Open", true);
        leftDoor.SetBool("Close", false);

        rightDoor.SetBool("Open", true);
        rightDoor.SetBool("Close", false);

        door.Play();

    }

    public void Close()
    {
        leftDoor.SetBool("Open", false);
        leftDoor.SetBool("Close", true);

        rightDoor.SetBool("Open", false);
        rightDoor.SetBool("Close", true);

        


    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Close();
            col.enabled = false;

            door.Play();

        }
    }


}
