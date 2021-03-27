using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeclasScript : MonoBehaviour
{

    public AudioSource tecla1;
    public AudioSource tecla2;
    public AudioSource tecla3;
    private int sound;

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
        sound = Random.Range(1, 3);
        if (sound == 1)
        {
            tecla1.pitch = Random.Range(0.8f, 1.2f);
            tecla1.Play();
        }
        else if (sound == 2)
        {
            tecla2.pitch = Random.Range(0.8f, 1.2f);
            tecla2.Play();
        }
        else if (sound == 3)
        {
            tecla3.pitch = Random.Range(0.8f, 1.2f);
            tecla3.Play();
        }
    }
}
