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

    private PassilloPolice pPolice;

    private PoliceTaller tallerPolice;


    private BossBehaviour boss;

    private BarrelExp barrel;

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

    public AudioSource sound;
    public bool playingSound;



    public GameObject laser;
    public GameObject spawnLaser;

    public GameObject hitWall;

    //public LineRenderer laser1;
    //public LineRenderer laser2;

    public Vector3 hiting;

    private LevelManager levelManager;

    public LineRenderer laser1;
    public LineRenderer laser2;

    public bool level2;


    // Start is called before the first frame update
    void Start()
    {

        level2 = false;
        //mainCamera = Camera.main;
        canShoot = false;
        ammo = maxAmmo;
        cadency = 0.2f;

        muzzleFlash.Stop();

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        change = GameObject.FindGameObjectWithTag("Holder").GetComponent<ChangeWeapon>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();

        //automatic = GameObject.FindGameObjectWithTag("Automatic").GetComponent<Automatic>();

        hud.SetMetralletaText(ammo, maxAmmo);

        disolve = 1;
        dissolveMat.SetFloat("Vector1_283E90B", disolve);
        dissolveMat2.SetFloat("Vector1_283E90B", disolve);
        playingSound = true;

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

                if (levelManager.canAct == true)
                {
                    canShoot = true;
                    canoAnim.SetBool("Disparar", true);
                    laser.SetActive(true);

                    if (playingSound == true && reloading == false)
                    {
                        SoundEffect();
                    }

                }
                
            }

            else
            {
                canoAnim.SetBool("Disparar", false);

                canShoot = false;
                sound.Stop();
                playingSound = true;

                laser.SetActive(false);

            }
        }

        else if (input.gamepadActive == true )
        {
            Gamepad Gp = InputSystem.GetDevice<Gamepad>();

            if (Gp.rightTrigger.isPressed && disolve <= 0 && reloading == false)
            {
                if (levelManager.canAct == true)
                {
                    canShoot = true;
                    canoAnim.SetBool("Disparar", true);
                    laser.SetActive(true);

                    if (playingSound == true && reloading == false)
                    {
                        SoundEffect();
                    }
                }


            }

            else
            {
                canoAnim.SetBool("Disparar", false);

                canShoot = false;
                sound.Stop();
                playingSound = true;

                laser.SetActive(false);
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
                hud.SetMetralletaText(ammo, maxAmmo);

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

    public void SoundEffect()
    {

        if (levelManager.canAct == true && manager.pause == false)
        {
            sound.Play();
            playingSound = false;
        }

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

        if (player.isDead == false && canShoot == true && levelManager.canAct == true)
        {
            if (canShoot && cadency >= waitCadency)
            {
                

                //muzzleFlash.Play();
                //Ray ray = mainCamera.ScreenPointToRay(screenPos);


                //cadency = 0;


                //automatic.SetActive();

                //Ray ray = mainCamera.ScreenPointToRay(mainCamera.transform.forward);
                RaycastHit hit;



                //for (int i = 0; i <= ammo; i++)
                //{


               
                if (Physics.Raycast(spawn.transform.position, spawn.transform.forward, out hit, distance)) //Aquí diem si el raig ha xocat amb quelcom
                {

                    
                    

                    if (hit.transform != null)
                    {

                        //Instantiate(hitNoDecal, hit.point, Quaternion.LookRotation(hit.normal));
                        Instantiate(hitWall, hit.point, Quaternion.LookRotation(hit.normal));

                        //Destroy(hitWall, 0.5f);

                    }

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

                    if (hit.transform.CompareTag("PassilloPolice"))
                    {
                        pPolice = hit.transform.GetComponent<PassilloPolice>();
                        pPolice.GetDamage(damage);
                        //enemyHit.Play(hit.transform)
                        //enemyHit.transform.position = 
                        //enemyHit.Play();
                        //Destroy(enemyHit, 1f);

                       
                    }

                    if (hit.transform.CompareTag("TallerPolice"))
                    {
                        tallerPolice = hit.transform.GetComponent<PoliceTaller>();
                        tallerPolice.GetDamage(damage);
                        //enemyHit.Play(hit.transform)
                        //enemyHit.transform.position = 
                        //enemyHit.Play();
                        //Destroy(enemyHit, 1f);


                    }

                    if (hit.transform.CompareTag("Boss"))
                    {
                        boss = hit.transform.GetComponent<BossBehaviour>();

                        
                        boss.GetDamage(damage);
                    }

                    if (hit.transform.CompareTag("Barril"))
                    {
                        barrel = hit.transform.GetComponent<BarrelExp>();

                        barrel.Explode();
                        
                    }

                    //if (hit.transform.tag == "Wall")
                    //{
                    //}  

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

        if (levelManager.canAct == true)
        {
            reloading = true;
            StartCoroutine(WaitForReload());
        }
        
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

    public void Level2()
    {
        level2 = true;
        maxAmmo = 60;
        ammo = maxAmmo;
        reloadTime = 2f;
        damage = 1;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
        
    //}

    IEnumerator WaitForReload()
    {
        change.reloading = true;

        canoAnim.SetBool("Disparar", false);

        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;
        hud.SetMetralletaText(ammo, maxAmmo);
        reloading = false;
        change.reloading = false;

        //canShoot = true;

    }

    //IEnumerator WaitForCadency() //La pots cridar cada x temps, el que tu vulguis
    //{
    //    canShoot = false;
    //    yield return new WaitForSeconds(cadency); //Quant temps espera per passar a la seguent linea. Es un corrutina
    //    canShoot = true;
    //}

}