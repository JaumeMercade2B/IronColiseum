using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronSpawn : MonoBehaviour
{
    public Transform dronSpawn;
    public GameObject dronGO;
    public float dronCounter;
    public float dronCounting;
    public int maxDrons;
    public int dronsSpawned;
    public bool canSpawn;
    public StartDronSpawn start;


    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false;
        dronsSpawned = 0;

        dronCounting = Random.Range(0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        if (dronsSpawned < maxDrons && start.canStart == true)
        {
            dronCounter += Time.deltaTime;

            if (dronCounter >= dronCounting)
            {
                Spawn();
            }
        }
    }

    public void Spawn()
    {
        Instantiate(dronGO, dronSpawn.transform.position, Quaternion.identity);
        dronsSpawned++;
        dronCounting = Random.Range(4f, 5f);
        dronCounter = 0;
    }
}
