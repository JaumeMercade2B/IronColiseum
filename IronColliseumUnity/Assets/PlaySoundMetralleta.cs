using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundMetralleta : MonoBehaviour
{

    public AudioSource metralleta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sound()
    {
        metralleta.Play();
    }

    public void Stop()
    {
        metralleta.Stop();
    }
}
