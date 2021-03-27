using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaVictory : MonoBehaviour
{
    private GameManager manager;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (manager.enemyCount == 3)
        {
            StartCoroutine(WaitOpen());
        }
    }

    IEnumerator WaitOpen()
    {
        yield return new WaitForSecondsRealtime(3);
        anim.SetTrigger("Puja");
    }
}
