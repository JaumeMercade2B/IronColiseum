using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserPosBoss : MonoBehaviour
{

    public LineRenderer laser;
    public GameObject raySpawn;
    public float distance;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
//    void Update()
//    {
//        RaycastHit hitInfo;

//        if (Physics.Raycast(raySpawn.transform.position, raySpawn.transform.forward, out hitInfo, distance))
//        {

//            if (hitInfo.transform.CompareTag("Player"))
//            {
//                player = hitInfo.transform.GetComponent<Transform>();
//                laser.SetPosition(1, new Vector3(1.5f, -1.5f, player.transform.position.z));
//            }


//            else
//            {
//                laser.SetPosition(1, new Vector3 (1.5f, -1.5f, 15));
//            }
            
//        }
//    }
}
