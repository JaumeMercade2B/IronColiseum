using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{

    public bool isDead;

    public float life;
    public float maxLife;

    private MenuManager menu;

    // Start is called before the first frame update
    void Start()
    {
        
        life = maxLife;
        isDead = false;

        menu = GameObject.FindGameObjectWithTag("Manager").GetComponent<MenuManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Dead();
        }
    }

    public void GetDamage(float damage)
    {
        life -= damage;
    }

    public void Dead()
    {
        isDead = true;
        menu.Victory();
        Destroy(gameObject);
    }
}
