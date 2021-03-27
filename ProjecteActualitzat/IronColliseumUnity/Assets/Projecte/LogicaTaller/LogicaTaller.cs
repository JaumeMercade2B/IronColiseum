using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaTaller : MonoBehaviour
{
    public int deadEnemies;
    public int maxEnemies;

    public Light buttonLight;


    // Start is called before the first frame update
    void Start()
    {
        deadEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (deadEnemies < maxEnemies)
        {
            buttonLight.color = Color.red;
        }

        else if (deadEnemies >= maxEnemies)
        {
            buttonLight.color = Color.green;
        }
    }
}
