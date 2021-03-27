using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColAttackArena : MonoBehaviour
{


    public ArenaIA enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.canAttack = false;
            //enemy.timeBetweenAttacks = 3;
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.canAttack = true;
            //enemy.alreadyAttacked = true;
        }
    }

}
