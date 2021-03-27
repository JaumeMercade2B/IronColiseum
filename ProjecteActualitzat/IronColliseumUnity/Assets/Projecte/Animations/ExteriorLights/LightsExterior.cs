using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsExterior : MonoBehaviour
{
    private Quaternion targetRotation;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetRotation = Quaternion.Euler(Random.Range(-50, 50), 0, 0);
        transform.rotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * speed);
    }
}
