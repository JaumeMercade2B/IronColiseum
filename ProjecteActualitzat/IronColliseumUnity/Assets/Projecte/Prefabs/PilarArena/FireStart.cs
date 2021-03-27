using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStart : MonoBehaviour
{

    public GameObject fire;

    private FPSController player;
    private LevelManager level;

    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        level = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (level.startArena == true)
        {
            fire.SetActive(true);
        }


        if (player.killedArena == true)
        {
            fire.SetActive(false);
        }
    }
}
