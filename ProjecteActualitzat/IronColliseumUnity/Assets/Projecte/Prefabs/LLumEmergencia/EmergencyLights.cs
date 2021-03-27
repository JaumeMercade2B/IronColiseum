using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyLights : MonoBehaviour
{
    public GameObject lights;
    private ImprovementCell manager;



    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("InteractCell").GetComponent<ImprovementCell>();

        lights.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.doorOpen == true)
        {
            LightsActive();
        }

        else
        {
            LightsInactive();
        }
    }


    private void LightsActive()
    {
        lights.SetActive(true);
    }

    private void LightsInactive()
    {
        lights.SetActive(false);
    }

}
