using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSecurity : MonoBehaviour
{

    public AudioSource destroied;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {

        destroied.Play();
        Destroy(gameObject,1f);
    }
}
