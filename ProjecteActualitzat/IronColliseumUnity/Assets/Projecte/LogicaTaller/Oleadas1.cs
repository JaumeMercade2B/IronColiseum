using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oleadas1 : MonoBehaviour
{

    public bool startSpawn;
    private Collider col;
    public bool alreadyStarted;

    // Start is called before the first frame update
    void Start()
    {
        startSpawn = false;
        alreadyStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            startSpawn = true;
            //alreadyStarted = true;
            //col.enabled = false;
        }
    }
}
