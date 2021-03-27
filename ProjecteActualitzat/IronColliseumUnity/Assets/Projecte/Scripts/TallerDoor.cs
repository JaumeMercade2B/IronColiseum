using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallerDoor : MonoBehaviour
{
    public Animator leftDoor;
    public Animator rightDoor;

    public AudioSource door;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Open()
    {

        door.Play();
        leftDoor.SetBool("Open", true);
        leftDoor.SetBool("Close", false);

        rightDoor.SetBool("Open", true);
        rightDoor.SetBool("Close", false);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            door.Play();
            Destroy(door, 1.5f);

            leftDoor.SetBool("Open", false);
            rightDoor.SetBool("Open", false);

            leftDoor.SetBool("Close", true);
            rightDoor.SetBool("Close", true);
        }
    }
}
