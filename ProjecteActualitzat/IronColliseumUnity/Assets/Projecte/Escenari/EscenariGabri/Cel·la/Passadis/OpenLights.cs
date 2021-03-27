using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLights : MonoBehaviour
{

    public GameObject light;


    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            light.SetActive(true);
        }
    }
}
