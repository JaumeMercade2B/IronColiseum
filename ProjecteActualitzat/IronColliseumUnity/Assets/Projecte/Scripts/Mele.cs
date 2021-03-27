using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mele : MonoBehaviour
{
    private Animator animator;
    public bool isAttacking;
    public float cadency = 0f;
    //public Collider col;
    public float damage = 3;

    public AudioSource hit;

    private EnemyBehaviour enemy;
    private FuckThePoliceBehaviour fuckPolice;
    private DronBehaviour dron;
    private SegurataBehaviour segurata;
    private PassilloPolice pPolice;
    private PoliceTaller tallerPolice;

    public bool disappear;
    public bool appear;
    public bool hasWeapon;

    public Material dissolveMat;
    public float disolve;

    public Transform spawn;
    public float distance;

    private DestroyTorreta destroyTorreta;
    private BossBehaviour boss;

    public LineRenderer laserLine;
    public float zPositionLaser;


    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        //col = GetComponent<Collider>();

        disolve = 1;
        dissolveMat.SetFloat("Vector1_283E90B", disolve);

        laserLine.SetPosition(1, Vector3.zero);

    }

    // Update is called once per frame
    void Update()
    {

        if (hasWeapon == true)
        {
            disolve -= 0.8f * Time.deltaTime;
            dissolveMat.SetFloat("Vector1_283E90B", disolve);

            
            laserLine.SetPosition(1, new Vector3(0, 0, zPositionLaser));

            if (zPositionLaser >= 150)
            {
                zPositionLaser = 150;
            }

            if (disolve <= 0)
            {
                zPositionLaser += 90f * Time.deltaTime;
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

            RaycastHit hitInfo;

            if (Physics.Raycast(spawn.transform.position, spawn.transform.forward, out hitInfo, distance))
            {
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    enemy = hitInfo.transform.GetComponent<EnemyBehaviour>();
                    enemy.GetDamage(damage);
                    //enemyHit.Play(hit.transform)
                    //enemyHit.transform.position = 
                    //enemyHit.Play();


                    Debug.Log("hit");
                }

                if (hitInfo.transform.CompareTag("Police"))
                {
                    fuckPolice = hitInfo.transform.GetComponent<FuckThePoliceBehaviour>();
                    fuckPolice.GetDamage(damage);
                    //enemyHit.Play(hit.transform)
                    //enemyHit.transform.position = 
                    //enemyHit.Play();


                    Debug.Log("hit");
                }

                if (hitInfo.transform.CompareTag("Dron"))
                {
                    dron = hitInfo.transform.GetComponent<DronBehaviour>();
                    dron.GetDamage(damage);
                    //enemyHit.Play(hit.transform)
                    //enemyHit.transform.position = 
                    //enemyHit.Play();


                    Debug.Log("hit");
                }

                if (hitInfo.transform.CompareTag("DestroyTorreta"))
                {
                    destroyTorreta = hitInfo.transform.GetComponent<DestroyTorreta>();
                    destroyTorreta.GetDamage(damage);
                }

                if (hitInfo.transform.CompareTag("Segurata"))
                {
                    segurata = hitInfo.transform.GetComponent<SegurataBehaviour>();
                    segurata.Dead();
                    //Destroy(gameObject);
                }


                if (hitInfo.transform.CompareTag("PassilloPolice"))
                {
                    pPolice = hitInfo.transform.GetComponent<PassilloPolice>();
                    pPolice.GetDamage(damage);
                    //Destroy(gameObject);
                }


                if (hitInfo.transform.CompareTag("TallerPolice"))
                {
                    tallerPolice = hitInfo.transform.GetComponent<PoliceTaller>();
                    tallerPolice.GetDamage(damage);
                    //Destroy(gameObject);
                }

                if (hitInfo.transform.CompareTag("Boss"))
                {
                    boss = hitInfo.transform.GetComponent<BossBehaviour>();
                    boss.GetDamage(damage);
                }
            }

            //StartCoroutine(WaitForAttack());

            cadency = 0;
            isAttacking = false;

        }

        else
        {
            animator.SetTrigger("Idle");
            //StopCoroutine(WaitForAttack());

            //col.enabled = false;
        }
    }

    public void Attack()
    {
        if (cadency >= 2f && hasWeapon == true)
        {
            //col.enabled = true;
            isAttacking = true;
            hit.Play();
            //StartCoroutine(WaitForAttack());


        }
        
        else
        {
            return;
        }
       
       
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        //if (isAttacking)
    //        //{
    //        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBehaviour>();
    //        enemy.GetDamage(damage);

    //        //}

    //    }

    //    if (other.tag == "Police")
    //    {
    //        //if (isAttacking)
    //        //{
    //        fuckPolice = other.gameObject.GetComponent<FuckThePoliceBehaviour>();
    //        fuckPolice.GetDamage(damage);

    //        //}

    //    }

    //    if (other.tag == "Dron")
    //    {
    //        //if (isAttacking)
    //        //{
    //        dron = GameObject.FindGameObjectWithTag("Dron").GetComponent<DronBehaviour>();
    //        dron.GetDamage(damage);

    //        //}

    //    }

    //    if (other.tag == "Segurata")
    //    {
    //        segurata = other.gameObject.GetComponent<SegurataBehaviour>();
    //        segurata.Dead();
    //        //Destroy(gameObject);
    //    }
    //}

    IEnumerator WaitForAttack()
    {

        
        yield return new WaitForSeconds(0.2f);
        cadency = 0;
        isAttacking = false;


    }

    //public bool GetAttack()
    //{
    //    return isAttacking;
    //}
}
