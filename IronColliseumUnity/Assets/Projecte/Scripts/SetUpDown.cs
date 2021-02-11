using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpDown : MonoBehaviour
{
    public ElevatorArena elevator;
    private FPSController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && player.killedArena == false)
        {
            elevator.Down();

        }
    }
}
