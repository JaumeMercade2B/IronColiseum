using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public bool startArena;

    public bool instantiateArena;

    public GameObject enemyArena;

    public GameObject spawnArena;

    public bool alreadyInstanciate;

    public int enemyCounter;

    public Collider col;

    private FPSController player;

    public int counterSegurata;

    public GameObject segurata;
    public GameObject spawnSegurata;

    public Transform SpawnBoss;
    public GameObject boss;
    public bool spawnedBoss;

    // Start is called before the first frame update
    void Start()
    {
        startArena = false;
        instantiateArena = false;
        alreadyInstanciate = false;
        enemyCounter = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();

        counterSegurata = 0;
        spawnedBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (instantiateArena == true && enemyCounter < 1)
        {
            Instantiate(enemyArena, spawnArena.transform.position, Quaternion.Euler(0, 180, 0));
            enemyCounter++;
        }

        if (player.killedArena == false)
        {
            col.enabled = false;
        }

        if (player.killedArena == true)
        {
            col.enabled = true;
        }

        if (player.killedArena == true && counterSegurata < 1)
        {
            Instantiate(segurata, spawnSegurata.transform.position, Quaternion.identity);
            counterSegurata++;
        }
        
    }

    public void InstantiateArena()
    {
        instantiateArena = true;

    }

    public void InstantiateBoss()
    {
        Instantiate(boss, SpawnBoss.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.killedArena = false;
            enemyCounter = 0;
            startArena = false;
        }
    }
}
