using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStairs : MonoBehaviour
{

    public bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stairs")
        {
            canJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Stairs")
        {
            canJump = false;
        }
    }
}
