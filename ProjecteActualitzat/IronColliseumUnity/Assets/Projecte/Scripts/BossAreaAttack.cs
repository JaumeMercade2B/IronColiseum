using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAreaAttack : MonoBehaviour
{

    public GameObject laser;
 

    // Start is called before the first frame update
    void Start()
    {
        laser.SetActive(false);
        StartCoroutine(WaitAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(3f);
        laser.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
