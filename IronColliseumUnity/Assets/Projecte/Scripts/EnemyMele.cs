using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMele : MonoBehaviour
{

    public ArenaIA enemy;
    private Animator animator;
    public FPSController player;
    public float damage = 1.5f;
    public float restDamage = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (enemy.canAttack == false)
        //{
        //    Attack();
        //}
    }


    public void Attack()
    {
        animator.SetBool ("Attack", true);
        //StartCoroutine(WaitAttack());
    }

    public void ReturnIdle()
    {
        animator.SetBool("Attack", false);
    }

    IEnumerator WaitAttack()
    {
        //animator.SetBool("Attack", false);
        yield return new WaitForSecondsRealtime(0.3f);

        animator.SetBool("Attack", false);

        yield return new WaitForSecondsRealtime(3f);

        //Attack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            
            if (player.shield > damage)
            {
                player.ShieldDamage(damage);
            }
            else if (player.shield <= damage && player.shield > 0)
            {
                restDamage = damage - player.shield;
                player.GetDamage(restDamage);
                player.shield = 0;
                restDamage = 0;
            }

            else if (player.shield <= 0)
            {
                player.GetDamage(damage);
            }
        }
    }
}
