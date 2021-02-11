using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTuercas : MonoBehaviour
{
    private FPSController FPScontroller;
    

    // Start is called before the first frame update
    void Start()
    {
        FPScontroller = FindObjectOfType<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FPScontroller.tuercas += 300;
            FPScontroller.ApparitionTuercas();
            
            FPScontroller.SoundTuercas();
            Destroy(gameObject);

        }


    }
}
