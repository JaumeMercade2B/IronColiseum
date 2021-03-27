using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPoint : MonoBehaviour
{

    public Transform[] points;
    public Transform destination;

    public int pointCounter;

    public float distance;
    public float previousDistance;

    public bool pointSet;


    // Start is called before the first frame update
    void Start()
    {
        pointCounter = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pointCounter);
    }

    public void GetPoint(Transform transform)
    {
        transform.transform.position = points[pointCounter].transform.position;
    }
}
