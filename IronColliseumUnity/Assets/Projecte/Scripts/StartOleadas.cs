using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOleadas : MonoBehaviour
{

    public bool startOleadas;
    public bool oleadaStarted;
    // Start is called before the first frame update
    void Start()
    {
        startOleadas = false;
        oleadaStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && oleadaStarted == false)
        {
            startOleadas = true;
            oleadaStarted = true;
        }
    }
}
