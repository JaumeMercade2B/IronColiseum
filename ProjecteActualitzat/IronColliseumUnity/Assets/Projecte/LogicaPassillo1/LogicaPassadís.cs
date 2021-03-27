using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPassadís : MonoBehaviour
{

    public int enemyCounter;
    public SecurityPassillo security;
    public Collider colOrdenador;

    // Start is called before the first frame update
    void Start()
    {
        enemyCounter = 0;
        colOrdenador.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCounter >= 2)
        {
            colOrdenador.enabled = true;
        }
    }
}
