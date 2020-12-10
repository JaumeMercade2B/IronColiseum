using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    public GameObject Tuto;
    private FPSController player;
    private ChangeWeapon cweapon;

    // Start is called before the first frame update
    void Start()
    {
        
        player = FindObjectOfType<FPSController>();
        cweapon = FindObjectOfType<ChangeWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.numTuto == 0)
        {
            if (player.hasMoved == true)
            {
                StartCoroutine(SetFalseMove());
                
            }
        }

        if (player.numTuto == 1)
        {
            if (player.hasJumped)
            {
                StartCoroutine(SetFalseJump());
               
            }
        }

        if (player.numTuto == 2)
        {
            if (cweapon.hasChanged)
            {
                StartCoroutine(SetFalseChangeWeapon());

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Tuto.SetActive(true);
        }
    }



    IEnumerator SetFalseMove()
    {
        yield return new WaitForSeconds(2);
        Tuto.SetActive(false);
        player.numTuto = 1;
        Destroy(GameObject.Find("TutorialMove"));
    }

    IEnumerator SetFalseJump()
    {
        yield return new WaitForSeconds(2);
        Tuto.SetActive(false);
        player.numTuto = 2;
        Destroy(GameObject.Find("TutorialJump"));
    }

    IEnumerator SetFalseChangeWeapon()
    {
        yield return new WaitForSeconds(2);
        Tuto.SetActive(false);
        player.numTuto = 3;
        Destroy(GameObject.Find("TutorialChangeWeapon"));
    }
}
