using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SegurataBehaviour : MonoBehaviour
{

    public float life;
    public bool isDead;
    private Collider restartCollider;
    private Collider teleportCollider;
    private Collider ascensor;
    private FPSController player;
    private Collider cellDoor;
    private Collider computer;
    private ComputerSecurity shield;

    public Transform spawnWeapon;
    public GameObject weaponDrop;

    private TallerDoor door;

    public float timeWalking;
    public float walkCounter;

    public float timeQuiet;
    public float quietCounter;

    public Vector3 newPos;

    private NavMeshAgent agent;

    private Transform point1;
    private Transform point2;
    private Transform point3;
    private Transform point4;

    public int destPoint;




    // Start is called before the first frame update
    void Start()
    {
        life = 0.1f;
        isDead = false;

        timeWalking = 2f;

        agent = GetComponent<NavMeshAgent>();

        restartCollider = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        teleportCollider = GameObject.FindGameObjectWithTag("InsideElevator").GetComponent<Collider>();
        ascensor = GameObject.FindGameObjectWithTag("AscensorCela").GetComponent<Collider>();

        cellDoor = GameObject.FindGameObjectWithTag("CellDoor").GetComponent<Collider>();
        shield = GameObject.FindGameObjectWithTag("ComputerSecurity").GetComponent<ComputerSecurity>();
        computer = GameObject.FindGameObjectWithTag("ComputerCell").GetComponent<Collider>();
        shield = GameObject.FindGameObjectWithTag("ComputerSecurity").GetComponent<ComputerSecurity>();
        door = GameObject.FindGameObjectWithTag("TallerDoor").GetComponent<TallerDoor>();


        point1 = GameObject.FindGameObjectWithTag("Cell1").GetComponent<Transform>();
        point2 = GameObject.FindGameObjectWithTag("Cell2").GetComponent<Transform>();
        point3 = GameObject.FindGameObjectWithTag("Cell3").GetComponent<Transform>();
        point4 = GameObject.FindGameObjectWithTag("Cell4").GetComponent<Transform>();

        destPoint = 1;


    }

    // Update is called once per frame
    void Update()
    {
        quietCounter += Time.deltaTime;
        walkCounter += Time.deltaTime;

        if (walkCounter <= timeWalking)
        {
            MoveR();
        }

        else
        {
            Quiet();
        }

    }

    public void MoveR()
    {
        agent.isStopped = false;


        if (destPoint == 1)
        {
            agent.SetDestination(point1.position);

            if (!agent.pathPending && agent.remainingDistance <= 0.5f)
            {
                destPoint = destPoint + 1;

                if (destPoint >= 5)
                {
                    destPoint = 1;
                }
            }

        }

        else if (destPoint == 2)
        {
            agent.SetDestination(point2.position);

            if (!agent.pathPending && agent.remainingDistance <= 0.5f)
            {
                destPoint = destPoint + 1;

                if (destPoint >= 5)
                {
                    destPoint = 1;
                }
            }
        }

        else if (destPoint == 3)
        {
            agent.SetDestination(point3.position);

            if (!agent.pathPending && agent.remainingDistance <= 0.5f)
            {
                destPoint = destPoint + 1;

                if (destPoint >= 5)
                {
                    destPoint = 1;
                }
            }
        }

        else if (destPoint == 4)
        {
            agent.SetDestination(point4.position);

            if (!agent.pathPending && agent.remainingDistance <= 0.5f)
            {
                destPoint = destPoint + 1;

                if (destPoint >= 5)
                {
                    destPoint = 1;
                }
            }
        }

    }

    public void Quiet()
    {
        agent.isStopped = true;

        StartCoroutine(WaitQuiet());
    }

    public void Dead()
    {

        Instantiate(weaponDrop, spawnWeapon.transform.position, Quaternion.identity);
        //door.Open();
        
        isDead = true;
        restartCollider.enabled = false;
        teleportCollider.enabled = false;
        cellDoor.enabled = false;
        ascensor.enabled = false;

        shield.Destroy();
        computer.enabled = true;

        player.killedArena = true;
        Destroy(gameObject);
    }

    IEnumerator WaitQuiet()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        timeWalking = Random.Range(1f, 3f);
        walkCounter = 0;
    }
}
