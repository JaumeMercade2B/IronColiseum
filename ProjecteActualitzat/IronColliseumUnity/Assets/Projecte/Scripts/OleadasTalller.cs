using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OleadasTalller : MonoBehaviour
{
    public float timeBetweenSpawn;
    public float minTime = 0.5f;
    public float maxTime = 2f;

    public float timeBetweenOleadas = 10;

    public int numberEnemies1 = 5;
    public int numberEnemies2 = 10;
    public int numberEnemies3= 15;

    public int numberEnemies;

    public float counter;
    public float counterOleadas;

    public bool oleada1;
    public bool oleada2;
    public bool oleada3;

    public StartOleadas startOleadas;

    public GameObject police;

    public int deadPolice;

    public bool finish;

    private TeleportPlayer teleport;

    public Transform dronSpawn;
    public GameObject dronGO;
    public float dronCounter;
    public float dronCounting;

    public bool start;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenSpawn = Random.Range(minTime, maxTime);
        startOleadas.startOleadas = false;
        oleada1 = true;
        deadPolice = 0;

        finish = false;
        start = false;

        teleport = GameObject.FindGameObjectWithTag("Player").GetComponent<TeleportPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += Time.deltaTime;
        counterOleadas += Time.deltaTime;


        if (startOleadas.startOleadas == true)
        {
            start = true;

            if (oleada1 == true)
            {
                Oleada1();
            }
            

            if (numberEnemies >= numberEnemies1)
            {
                oleada1 = false;

                numberEnemies = 0;


            }

            if (deadPolice >= numberEnemies1)
            {
                counterOleadas = 0;
                oleada2 = true;
                deadPolice = 0;
                
                startOleadas.startOleadas = false;
            }

        }

        if (oleada2 == true)
        {
            

            if (counterOleadas >= timeBetweenOleadas && numberEnemies < numberEnemies2)
            {
                Oleada2();
            }

            //if (numberEnemies >= numberEnemies2)
            //{
                
            //    numberEnemies = 0;

                
            //}

            if (deadPolice >= numberEnemies2)
            {
                oleada3 = true;
                counterOleadas = 0;
                deadPolice = 0;
                numberEnemies = 0;
                oleada2 = false;
            }



        }

        if (oleada3 == true)
        {

            

            if (counterOleadas >= timeBetweenOleadas && numberEnemies < numberEnemies3)
            {
                Oleada3();
            }

            //if (numberEnemies >= numberEnemies3)
            //{
            //    finish = true;
 

            //}

            if (deadPolice >= numberEnemies3)
            {
                counterOleadas = 0;
                teleport.TeleportBoss();
                oleada3 = false;
                finish = true;
            }


        }

        
        if (finish == false && start == true)
        {
            dronCounting += Time.deltaTime;

            if (dronCounting >= dronCounter)
            {
                SpawnDron();

                dronCounting = 0;
            }
        }

    }

    public void Spawn()
    {
        Instantiate(police, transform.position, Quaternion.identity);
    }

    public void SpawnDron()
    {
        Instantiate(dronGO, dronSpawn.transform.position, Quaternion.identity);
    }

    public void Oleada1()
    {
        if (counter >= timeBetweenSpawn)
        {
            Spawn();
            counter = 0;
            timeBetweenSpawn = Random.Range(minTime, maxTime);
            numberEnemies += 1;
        }
    }

    public void Oleada2()
    {
        if (counter >= timeBetweenSpawn)
        {
            Spawn();
            counter = 0;
            timeBetweenSpawn = Random.Range(minTime, maxTime);
            numberEnemies += 1;
        }
    }

    public void Oleada3()
    {
        if (counter >= timeBetweenSpawn)
        {
            Spawn();
            counter = 0;
            timeBetweenSpawn = Random.Range(minTime, maxTime);
            numberEnemies += 1;
        }
    }
}
