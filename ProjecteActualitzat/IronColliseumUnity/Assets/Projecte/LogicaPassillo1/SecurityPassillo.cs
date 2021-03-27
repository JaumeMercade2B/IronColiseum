using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityPassillo : MonoBehaviour
{

    public AudioSource destroied;
    public LogicaPassadís logica;
    private bool audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (logica.enemyCounter >= 2)
        {
            Destroy();
        }
    }


    public void Destroy()
    {

        Destroy(gameObject, 1f);
    }
}
