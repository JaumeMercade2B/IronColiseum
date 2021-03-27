using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{

    public GameObject enemiGO;
    public Oleadas1 oleadas;
    public int maxEnemies;
    public int enemies;

    public float timeBetweenEnemies;
    public float timeCounter;

    // Start is called before the first frame update
    void Start()
    {
        

        timeBetweenEnemies = Random.Range(2f, 4f);
        enemies = 0;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (oleadas.startSpawn)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= timeBetweenEnemies)
            {
                Instantiate(enemiGO, transform.position, Quaternion.identity);
                timeBetweenEnemies = Random.Range(2f, 4f);
                enemies++;
                timeCounter = 0;

            }
        }

        if (enemies >= maxEnemies)
        {
            oleadas.startSpawn = false;
        }
    }
}
