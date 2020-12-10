using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTuercas : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotationSpeed = 0.3f;
    private GameManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {

        if (manager.openMenu == false)
        {
            transform.Rotate(0f, rotationSpeed, 0f);

        }
    }
}
