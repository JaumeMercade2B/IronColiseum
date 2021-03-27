using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldShader : MonoBehaviour
{

    public Material shield;
    public float op;
    public FPSController player;
    public float speed;
    public GameObject shieldMesh;

    // Start is called before the first frame update
    void Start()
    {
        op = 0;
        shield.SetFloat("Vector1_F8EA4A1F", op);
        shieldMesh.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (player.shield <= 0)
        {
            Debug.Log("Shield");
            shieldMesh.SetActive(true);
            op += speed * Time.deltaTime;
            shield.SetFloat("Vector1_F8EA4A1F", op);

            if (op >= 1)
            {
                op = 1;
                shield.SetFloat("Vector1_F8EA4A1F", op);

            }

            
        }

        if (player.shield != 0)
        {
            op = 0;
            shield.SetFloat("Vector1_F8EA4A1F", op);
            shieldMesh.SetActive(false);


        }


    }
}
