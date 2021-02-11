using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mele : MonoBehaviour
{
    private Animator animator;
    public bool isAttacking;
    public float cadency = 0f;
    public Collider col;
    public float damage = 3;

    public AudioSource hit;

    private EnemyBehaviour enemy;
    private FuckThePoliceBehaviour fuckPolice;
    private DronBehaviour dron;
    private SegurataBehaviour segurata;

    public bool disappear;
    public bool appear;
    public bool hasWeapon;

    public Material dissolveMat;
    public float disolve;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //col = GetComponent<Collider>();

        disolve = 1;
        dissolveMat.SetFloat("Vector1_283E90B", disolve);

    }

    // Update is called once per frame
    void Update()
    {

        if (hasWeapon == true)
        {
            disolve -= 0.8f * Time.deltaTime;
            dissolveMat.SetFloat("Vector1_283E90B", disolve);

            if (disolve <= 0)
            {
                disolve = 0;
                dissolveMat.SetFloat("Vector1_283E90B", disolve);
                appear = false;
                cadency += Time.deltaTime;
            }
        }

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
            col.enabled = false;
        }
    }

    public void Attack()
    {
        if (cadency >= 2f && hasWeapon == true)
        {
            col.enabled = true;
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

        if (other.tag == "Police")
        {
            //if (isAttacking)
            //{
            fuckPolice = other.gameObject.GetComponent<FuckThePoliceBehaviour>();
            fuckPolice.GetDamage(damage);

            //}

        }

        if (other.tag == "Dron")
        {
            //if (isAttacking)
            //{
            dron = GameObject.FindGameObjectWithTag("Dron").GetComponent<DronBehaviour>();
            dron.GetDamage(damage);

            //}

        }

        if (other.tag == "Segurata")
        {
            segurata = other.gameObject.GetComponent<SegurataBehaviour>();
            segurata.Dead();
            //Destroy(gameObject);
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
