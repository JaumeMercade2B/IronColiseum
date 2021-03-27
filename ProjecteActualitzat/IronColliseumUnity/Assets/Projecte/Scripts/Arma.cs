using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class Arma : MonoBehaviour
{
    /*
    private FPSController fpsController;
    public float amount = 0.02f;
    public float maxamount = 0.03f;
    public float smooth = 3;
    private Quaternion def;
    */

    public VisualEffect muzzleFlash;

    public AudioSource shooting;

    public Animator arma1Animator;

    private PlayerControls controls;

    public GameObject spawn;

    private float timeCounter;
    public float cadency = 0.2f;
    public float ammo = 10;
    private float maxAmmo = 10;
    public float reloadTime = 3;
    public bool reloading;

    public GameObject shootGO;
    public bool shoot = true;
    private Camera mainCamera;

    private GameManager manager;

    Ray ray;
    RaycastHit hit;
    private int distance = 50;

    private EnemyBehaviour enemy;

    private HUD hud;

    private ChangeWeapon change;

    private FPSController player;

    public Material dissolveMat;
    public float disolve;

    public bool appear;

    public bool hudAppear;
    public bool disappear;

    public bool hasWeapon;

    public float damage;
    public float maxDamage;

    public bool level2;

    private LevelManager levelManager;
    void Awake()
    {
        /*
        fpsController = FindObjectOfType<FPSController>();
        def = transform.localRotation;
        */

        if (level2 == false)
        {
            maxDamage = 1;
        }

        if (level2 == true)
        {
            maxDamage = 2;
        }

        damage = maxDamage;

        controls = new PlayerControls();
        mainCamera = Camera.main;

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent < GameManager > ();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();


        ammo = maxAmmo;
        reloading = false;

        hasWeapon = false;

        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        change = GameObject.FindGameObjectWithTag("Holder").GetComponent<ChangeWeapon>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();


        SetActive();
        hud.SetAmmoText(ammo);

        disolve = 1;
        dissolveMat.SetFloat("Vector1_283E90B", disolve);

    }

    private void Start()
    {
        muzzleFlash.Stop();
    }

    public void Update()
    {
        damage = maxDamage;


        if (level2 == false)
        {
            maxDamage = 1;
        }

        if (level2 == true)
        {
            maxDamage = 2;
        }
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    void FixedUpdate()
    {
        /*
        float factorZ = -(Input.GetAxis("Horizontal")) * amount;
        //float factorY = -(Input.GetAxis("Jump")) * amount;
        //float factorZ = -Input.GetAxis("Vertical") * amount;

        //if (factorX > maxamount)
        //factorX = maxamount;

        //if (factorX < -maxamount)
        //factorX = -maxamount;

        //if (factorY > maxamount)
        //factorY = maxamount;

        //if (factorY < -maxamount)
        //factorY = -maxamount;

        if (factorZ > maxamount)
            factorZ = maxamount;

        if (factorZ < -maxamount)
            factorZ = -maxamount;

        Quaternion Final = Quaternion.Euler(0, 0, def.z + factorZ);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Final, (Time.deltaTime * amount) * smooth);
        */

        if (hasWeapon == false)
        {
            muzzleFlash.Stop();
            shoot = false;
        }

        if (!shoot)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= cadency)
            {

                if (ammo > 0 && reloading == false && player.isDead == false)
                {
                    shoot = true;
                    timeCounter = 0;
                }

                else
                {
                    Reload();
                }
                
            }
        }

        if (appear == true && hasWeapon == true)
        {
            shoot = false;
            disolve -= 0.8f * Time.deltaTime;
            dissolveMat.SetFloat("Vector1_283E90B", disolve);
            if (disolve <= 0)
            {
                disolve = 0;
                dissolveMat.SetFloat("Vector1_283E90B", disolve);
                hudAppear = true;
                shoot = true;
                appear = false;
            }
        }

        if (disappear == true)
        {
            shoot = false;
            disolve += 0.8f * Time.deltaTime;
            dissolveMat.SetFloat("Vector1_283E90B", disolve);

            if (disolve >= 1)
            {
                spawn.SetActive(false);
            }
            
        }

        //PointingEnemy();
    }

    public void Shoot()
    {
        if (!shoot || player.isDead == true || hasWeapon == false)
        {
            return;
        }

        
        if (manager.pause == false && reloading == false && levelManager.canAct == true)
        {
            muzzleFlash.Play();
            arma1Animator.SetTrigger("Shoot");
            shooting.Play();
            shoot = false;
            //GameObject bulletObject = Instantiate(shootGO, transform.position, Quaternion.identity) as GameObject;
            GameObject bulletObject = Instantiate(shootGO, transform.position, Quaternion.identity);
            bulletObject.GetComponent<Rigidbody>().AddForce(transform.forward * 0.5f);
            bulletObject.transform.forward = mainCamera.transform.forward;
            if (player.godMode == false)
            {
                ammo--;
            }
            
            hud.SetAmmoText(ammo);
        }


    }

    public void Reload()
    {
        if (reloading || ammo == maxAmmo || change.currentWeapon != 0 || levelManager.canAct == false)
        {
            return;
        }
        arma1Animator.SetBool("IsReloading", true);
        reloading = true;
        StartCoroutine(WaitForReload());
    }
    public void SetActive()
    {
        if (change.ReturnCurrent() == 0)
        {
            disappear = false;
            spawn.SetActive(true);
            appear = true;

            
        }

        else if (change.ReturnCurrent() != 0)
        {
            hudAppear = false;
            disappear = true;
            
        }
    }

    public void Level2()
    {
        maxAmmo = 20;
        ammo = maxAmmo;
        reloadTime = 1.5f;
        level2 = true;
        hud.SetAmmoText(ammo);

    }



    IEnumerator WaitForReload()
    {
        change.reloading = true;
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;        
        reloading = false;
        hud.SetAmmoText(ammo);
        arma1Animator.SetBool("IsReloading", false);
        change.reloading = false;

    }

}