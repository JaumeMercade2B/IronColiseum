using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegurataBehaviour : MonoBehaviour
{

    public float life;
    public bool isDead;
    private Collider restartCollider;
    private Collider teleportCollider;
    private FPSController player;
    private Collider cellDoor;
    private Collider computer;
    private ComputerSecurity shield;

    public Transform spawnWeapon;
    public GameObject weaponDrop;
   

    // Start is called before the first frame update
    void Start()
    {
        life = 0.1f;
        isDead = false;

        restartCollider = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        teleportCollider = GameObject.FindGameObjectWithTag("InsideElevator").GetComponent<Collider>();
        cellDoor= GameObject.FindGameObjectWithTag("CellDoor").GetComponent<Collider>();
        shield = GameObject.FindGameObjectWithTag("ComputerSecurity").GetComponent<ComputerSecurity>();
        computer = GameObject.FindGameObjectWithTag("ComputerCell").GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead()
    {

        Instantiate(weaponDrop, spawnWeapon.transform.position, Quaternion.identity);
        
        isDead = true;
        restartCollider.enabled = false;
        teleportCollider.enabled = false;
        cellDoor.enabled = false;
        shield.Destroy();
        computer.enabled = true;

        player.killedArena = true;
        Destroy(gameObject);
    }
}
