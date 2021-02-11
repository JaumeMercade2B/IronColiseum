using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mele : MonoBehaviour
{
    private Animator animator;
    public bool isAttacking;
    public float cadency = 0f;
    private Collider col;
    public float damage = 3;

    public AudioSource hit;

    public EnemyBehaviour enemy;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {

        cadency += Time.deltaTime;

        if (isAttacking)
        {

            animator.SetTrigger("Attack");
            cadency = 0;
            isAttacking = false;
        }

        else
        {
            animator.SetTrigger("Idle");
        }
    }

    public void Attack()
    {
        if (cadency >= 2f)
        {
            isAttacking = true;
            hit.Play();
            StartCoroutine(WaitForAttack());
        }
        
        else
        {
            return;
        }
       
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //if (isAttacking)
            //{
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBehaviour>();
            enemy.GetDamage(damage);
            
            //}
  
        }
    }

    IEnumerator WaitForAttack()
    {

        col.enabled = !col.enabled;
        yield return new WaitForSeconds(1);
        col.enabled = !col.enabled;

    }

    //public bool GetAttack()
    //{
    //    return isAttacking;
    //}
}
