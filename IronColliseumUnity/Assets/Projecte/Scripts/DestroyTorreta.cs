using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTorreta : MonoBehaviour
{

    public float life;

    private TorretaBehaviour torreta;

    public bool died;

    // Start is called before the first frame update
    void Start()
    {
        torreta = GameObject.FindGameObjectWithTag("Torreta").GetComponent<TorretaBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            if (died == false)
            {
                Dead();
            }
        }
    }

    public void GetDamage(float damage)
    {
        life -= damage;
    }

    public void Dead()
    {

        torreta.SetInnactive();
        Destroy(gameObject, 0.5f);
        died = true;

    }


}
