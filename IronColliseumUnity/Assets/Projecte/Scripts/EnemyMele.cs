using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMele : MonoBehaviour
{

    private ArenaIA enemy;
    public Animator animator;
    private FPSController player;
    public float damage = 1.5f;
    public float restDamage = 0f;
    private EnemyBehaviour enemyB;

    public Collider col;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        enemyB = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBehaviour>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ArenaIA>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();

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
        col.enabled = true;

        animator.SetBool ("Melee", true);
        //StartCoroutine(WaitAttack());
    }

    public void ReturnIdle()
    {
        col.enabled = false;

        animator.SetBool("Melee", false);
    }

    IEnumerator WaitAttack()
    {
        //animator.SetBool("Attack", false);
        yield return new WaitForSecondsRealtime(0.3f);

        //col.enabled = false;

        animator.SetBool("Melee", false);

        yield return new WaitForSecondsRealtime(3f);

        //Attack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && enemyB.dead == false)
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
