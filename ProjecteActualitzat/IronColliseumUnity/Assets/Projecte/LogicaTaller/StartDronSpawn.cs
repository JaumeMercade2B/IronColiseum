using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDronSpawn : MonoBehaviour
{

    public bool canStart;

    // Start is called before the first frame update
    void Start()
    {
        canStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canStart = true;
        }
    }
}
