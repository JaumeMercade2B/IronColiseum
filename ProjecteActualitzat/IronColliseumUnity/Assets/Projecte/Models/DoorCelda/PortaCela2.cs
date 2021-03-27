using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaCela2 : MonoBehaviour
{
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Open", true);
            animator.SetBool("Close", false);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Open", false);
            animator.SetBool("Close", true);
        }
    }
}
