using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class Metralleta : MonoBehaviour
{

    public VisualEffect muzzleFlash;
    public VisualEffect enemyHit;
    public VisualEffect hitNoDecal;

    public bool canShoot = true;

    public int maxAmmo = 30;
    public int ammo;

    public float reloadTime = 0.5f;
    public bool reloading;

    public float damage = 1;
    public float cadency = 0;
    public float waitCadency= 0.01f;

    public float distance = 50;

    public Transform spawn;

    public Camera mainCamera;

    private GameManager manager;

    private ChangeWeapon change;

    private EnemyBehaviour enemy;

    private FuckThePoliceBehaviour fuckPolice;

    private DronBehaviour dron;

    private DestroyTorreta destroyTorreta;

    private SegurataBehaviour segurata;

    private BossBehaviour boss;

    private HUD hud;

    private FPSController player;

    public DetectInput input;


    public Material dissolveMat;
    public Material dissolveMat2;

    public float disolve;

    public bool hudAppear;
    public bool disappear;
    public bool appear;

    public Animator canoAnim;

    public PlaySoundMetralleta sound;

    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = Camera.main;
        canShoot = false;
        ammo = maxAmmo;
        cadency = 0.2f;

        muzzleFlash.Stop();

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        change = GameObject.FindGameObjectWithTag("Holder").GetComponent<ChangeWeapon>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();

        //automatic = GameObject.FindGameObjectWithTag("Automatic").GetComponent<Automatic>();

        hud.SetMetralletaText(ammo, maxAmmo);

        disolve = 1;
        dissolveMat.SetFloat("Vector1_283E90B", disolve);
        dissolveMat2.SetFloat("Vector1_283E90B", disolve);


    }

    public void FixedUpdate()
    {
        SetActive();
        cadency += Time.deltaTime;
        Debug.DrawRay(spawn.transform.position, spawn.transform.forward * distance, Color.green);

        Shoot();

        
        if (input.gamepadActive == false)
        {
            Mouse kb = InputSystem.GetDevice<Mouse>();

            if (kb.leftButton.isPressed &&  disolve <= 0 && reloading == false)
            {
                canShoot = true;
                canoAnim.SetBool("Disparar", true);
            }

            else
            {
                canoAnim.SetBool("Disparar", false);

                canShoot = false;
                sound.Stop();
            }
        }

        else if (input.gamepadActive == true )
        {
            Gamepad Gp = InputSystem.GetDevice<Gamepad>();

            if (Gp.rightTrigger.isPressed && disolve <= 0 && reloading == false)
            {
                canShoot = true;
                canoAnim.SetBool("Disparar", true);

            }

            else
            {
                canoAnim.SetBool("Disparar", false);

                canShoot = false;
                sound.Stop();
            }
        }

        if (appear == true)
        {
            //canShoot = false;
            disolve -= 0.8f * Time.deltaTime;
            dissolveMat.SetFloat("Vector1_283E90B", disolve);
            dissolveMat2.SetFloat("Vector1_283E90B", disolve);

            if (disolve <= 0)
            {
                disolve = 0;
                dissolveMat.SetFloat("Vector1_283E90B", disolve);
                dissolveMat2.SetFloat("Vector1_283E90B", disolve);

                hudAppear = true;
                //canShoot = true;
                appear = false;
            }
        }

        if (disappear == true)
        {
            canShoot = false;
            disolve += 0.8f * Time.deltaTime;
            dissolveMat.SetFloat("Vector1_283E90B", disolve);

            if (disolve >= 1)
            {
                gameObject.SetActive(false);
            }

        }





        var allGamepads = Gamepad.all;


        


        //if (!canShoot)
        //{
        //    automatic.SetInactive();

        //}
    }

    // Update is called once per frame
    public void OnShoot()
    {
        

         
        
    }

    public void Shoot()
    {

        if (reloading || manager.pause == true || player.isDead == true)
        {
            return;
        }

        if (ammo <= 0)
        {
            canShoot = false;
            Reload();
            return;
        }

        if (player.isDead == false && canShoot == true)
        {
            if (canShoot && cadency >= waitCadency)
            {


                muzzleFlash.Play();
                //Ray ray = mainCamera.ScreenPointToRay(screenPos);


                //cadency = 0;


                //automatic.SetActive();

                //Ray ray = mainCamera.ScreenPointToRay(mainCamera.transform.forward);
                RaycastHit hit;

                //for (int i = 0; i <= ammo; i++)
                //{

                if (Physics.Raycast(spawn.transform.position, spawn.transform.forward, out hit, distance)) //Aquí diem si el raig ha xocat amb quelcom
                {

                    Debug.Log(hit.transform.name);
                    if (hit.transform.CompareTag("Enemy"))
                    {
                        enemy = hit.transform.GetComponent<EnemyBehaviour>();
                        enemy.GetDamage(damage);
                        //enemyHit.Play(hit.transform)
                        //enemyHit.transform.position = 
                        //enemyHit.Play();
                        Destroy(enemyHit, 1f);

                        Debug.Log("hit");
                    }

                    if (hit.transform.CompareTag("Police"))
                    {
                        fuckPolice = hit.transform.GetComponent<FuckThePoliceBehaviour>();
                        fuckPolice.GetDamage(damage);
                        //enemyHit.Play(hit.transform)
                        //enemyHit.transform.position = 
                        //enemyHit.Play();
                        Destroy(enemyHit, 1f);

                        Debug.Log("hit");
                    }

                    if (hit.transform.CompareTag("Dron"))
                    {
                        dron = hit.transform.GetComponent<DronBehaviour>();
                        dron.GetDamage(damage);
                        //enemyHit.Play(hit.transform)
                        //enemyHit.transform.position = 
                        //enemyHit.Play();
                        Destroy(enemyHit, 1f);

                        Debug.Log("hit");
                    }

                    if (hit.transform.CompareTag("DestroyTorreta"))
                    {
                        destroyTorreta = hit.transform.GetComponent<DestroyTorreta>();
                        destroyTorreta.GetDamage(damage);
                    }

                    if (hit.transform.CompareTag("Segurata"))
                    {
                        segurata = hit.transform.GetComponent<SegurataBehaviour>();
                        segurata.Dead();
                        //Destroy(gameObject);
                    }

                    if (hit.transform.CompareTag("Boss"))
                    {
                        boss = hit.transform.GetComponent<BossBehaviour>();
                        boss.GetDamage(damage);
                    }

                }
                //}

                //Debug.Log("Shoot");
                if (player.godMode == false)
                {
                    ammo--;
                }

                hud.SetMetralletaText(ammo, maxAmmo);
                cadency = 0;
            }

            if (ammo <= 0)
            {
                ammo = 0;
                Reload();
            }

        }


    }

    public void StopShoot()
    {
        canShoot = false;
    }

    public void Reload()
    {
        if (reloading || ammo == maxAmmo || manager.pause == true || change.currentWeapon != 1)
        {
            return;
        }

        reloading = true;
        StartCoroutine(WaitForReload());
    }

    public void SetActive()
    {
        if (change.ReturnCurrent() == 1)
        {
            disappear = false;

            gameObject.SetActive(true);
            appear = true;

        }

        else if (change.ReturnCurrent() != 1)
        {
            //gameObject.SetActive(false);
            hudAppear = false;
            disappear = true;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
        
    //}

    IEnumerator WaitForReload()
    {
        canoAnim.SetBool("Disparar", false);

        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;
        hud.SetMetralletaText(ammo, maxAmmo);
        reloading = false;
        //canShoot = true;
   
    }

    //IEnumerator WaitForCadency() //La pots cridar cada x temps, el que tu vulguis
    //{
    //    canShoot = false;
    //    yield return new WaitForSeconds(cadency); //Quant temps espera per passar a la seguent linea. Es un corrutina
    //    canShoot = true;
    //}

}