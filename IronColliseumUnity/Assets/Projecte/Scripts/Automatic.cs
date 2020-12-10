using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : MonoBehaviour
{

    public float damage = 0.5f;
    private EnemyBehaviour enemy;

    // Start is called before the first frame update

    private void Start()
    {
        SetInactive();
    }

    public void SetActive()
    {
        gameObject.SetActive(true);
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy = other.gameObject.GetComponent<EnemyBehaviour>();
            enemy.GetDamage(damage);
        }
    }
}
