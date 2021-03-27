using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TorretaBehaviour : MonoBehaviour
{

    public float ammo;
    public float maxAmmo;


    public bool reload;
    public bool canShoot;
    public bool isActive;

    public float cadency;
    public float waitCadency;

    public float distance;

    public float damage;
    public float restDamage = 0f;

    private FPSController player;

    public VisualEffect bala;
    public GameObject spawnBala;

    public Collider col;

    public Animator LeftBraç;
    public Animator RightBraç;
    public Animator Torreta;
    public Animator CenterCanon;
    public Animator LeftCanon;
    public Animator RightCanon;
    public Animator RightTornillo;
    public Animator LeftTornillo;


    public GameObject torreta;

    private Transform playerTrans;

    private DestroyTorreta dead;

    public Transform spawnRay;

    public GameObject laser;


    // Start is called before the first frame update
    void Start()
    {
        waitCadency = 0.3f;
        distance = 50;
        damage = 0.5f;
        maxAmmo = Random.Range(40, 60);
        ammo = maxAmmo;

        isActive = true;
        canShoot = false;
        bala.Stop();

        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        dead = GameObject.FindGameObjectWithTag("DestroyTorreta").GetComponent<DestroyTorreta>();

        laser.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //if (canShoot == true && dead.died == false)
        //{
        //    gameObject.transform.LookAt(playerTrans);
        //}
        cadency += Time.deltaTime;

        if (canShoot == false)
        {
            laser.SetActive(false);
        }

        if (canShoot && cadency >= waitCadency && canShoot == true && dead.died == false)
        {

            laser.SetActive (true);

            bala.Play();

            RaycastHit hit;

            if (Physics.Raycast(spawnRay.transform.position, transform.forward, out hit, distance)) //Aquí diem si el raig ha xocat amb quelcom
            {

                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("Player"))
                {
                    player = hit.transform.GetComponent<FPSController>();
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
                    Debug.Log("hit");
                }

                ammo--;
                cadency = 0;
            }

            if (ammo <= 0)
            {
                maxAmmo = Random.Range(40, 60);
                Reload();
            }
        }
    }

    //public void Shoot()
    //{
    //    if (ammo <= 0)
    //    {
    //        maxAmmo = Random.Range(40, 60);
    //        Reload();
            
    //    }

    //    canShoot = true;
    //}

    public void Reload()
    {
        canShoot = false;
        bala.Stop();
        ammo = maxAmmo;
        StartCoroutine(WaitReload());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Activate());
        }
    }

    public void SetInnactive()
    {
        canShoot = false;

        Torreta.SetBool("Desplega", false);
        CenterCanon.SetBool("Desplega", false);
        LeftCanon.SetBool("Desplega", false);
        RightCanon.SetBool("Desplega", false);

        Torreta.SetBool("Shoot", false);
        CenterCanon.SetBool("Shoot", false);
        LeftCanon.SetBool("Shoot", false);
        RightCanon.SetBool("Shoot", false);

        Torreta.SetBool("Recarga", false);
        CenterCanon.SetBool("Recarga", false);
        LeftCanon.SetBool("Recarga", false);
        RightCanon.SetBool("Recarga", false);


        Torreta.SetBool("Dead", true);
        CenterCanon.SetBool("Dead", true);
        LeftCanon.SetBool("Dead", true);
        RightCanon.SetBool("Dead", true);

    }



    IEnumerator WaitReload()
    {
        Torreta.SetBool("Desplega", false);
        CenterCanon.SetBool("Desplega", false);
        LeftCanon.SetBool("Desplega", false);
        RightCanon.SetBool("Desplega", false);

        Torreta.SetBool("Shoot", false);
        CenterCanon.SetBool("Shoot", false);
        LeftCanon.SetBool("Shoot", false);
        RightCanon.SetBool("Shoot", false);

        Torreta.SetBool("Recarga", true);
        CenterCanon.SetBool("Recarga", true);
        LeftCanon.SetBool("Recarga", true);
        RightCanon.SetBool("Recarga", true);


        yield return new WaitForSeconds(Random.Range(3, 5));

        Torreta.SetBool("Recarga", false);
        CenterCanon.SetBool("Recarga", false);
        LeftCanon.SetBool("Recarga", false);
        RightCanon.SetBool("Recarga", false);

        Torreta.SetBool("Shoot", true);
        CenterCanon.SetBool("Shoot", true);
        LeftCanon.SetBool("Shoot", true);
        RightCanon.SetBool("Shoot", true);

        yield return new WaitForSeconds(0.5f);


        canShoot = true;
    }

    IEnumerator Activate()
    {
        LeftBraç.SetBool("Desplega", true);
        RightBraç.SetBool("Desplega", true);
        Torreta.SetBool("Desplega", true);
        CenterCanon.SetBool("Desplega", true);
        LeftCanon.SetBool("Desplega", true);
        RightCanon.SetBool("Desplega", true);
        RightTornillo.SetBool("Desplega", true);
        LeftTornillo.SetBool("Desplega", true);

        yield return new WaitForSeconds(2.8f);
        canShoot = true;
        Destroy(col);
    }

}
