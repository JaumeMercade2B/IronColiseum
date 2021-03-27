using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserMagnitude : MonoBehaviour
{
    public LineRenderer line;
    public Metralleta metralleta;
    public GameObject spawn;
    private Camera mainCamera;

    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //transform.forward = mainCamera.transform.forward;

        if (Physics.Raycast(spawn.transform.position, spawn.transform.forward, out hit, 20))
        {
            line.SetPosition(1,new Vector3 (0, 0, hit.distance));
            //line.SetPosition(1, new Vector3(0, hit.distance, 0));
            //line.SetPosition(1, new Vector3(hit.distance, 0, 0));

            //Debug.Log(hit.point);
        }



    }
}
