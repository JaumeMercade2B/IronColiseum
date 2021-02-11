using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;


public class FPSController : MonoBehaviour
{
    private GameManager manager;
    private HUD hud;

    public float life;
    public float maxLife = 10;

    private bool reciveDamage;

    public float shield;
    public float maxShield = 4;
    [SerializeField] float waitShield = 5;
    [SerializeField] float cooldownShield = 0;
    [SerializeField] float speedCharge = 0.1f;
    [SerializeField] bool shader;



    [SerializeField] float totalLife;



    public Slider playerLife;
    public Image dashUI;

    public float tuercas;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float normalSpeed = 5f;



    private bool jump;
    [SerializeField] private float jumpCoolDown;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool holdingSpace;
    [SerializeField] public bool isGrounded;
    public LayerMask groundMask;
    Ray ray;
    RaycastHit hit;
    public JumpStairs jumpStairs;


    private bool dash;

    [SerializeField] private bool canDash;
    [SerializeField] private int dashCapacity;
    [SerializeField] private bool isDashing;
    [SerializeField] private float waitDash;
    [SerializeField] private float waitDash2;
    [SerializeField] private float timeToDash = 2f;
    [SerializeField] private float timeDashing = 0f;
    [SerializeField] private float dashDuration = 1f;
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private int dashes = 2;
    [SerializeField] private bool twoDashes;
    [SerializeField] private Vector3 dashDirection;




    public Animator Andar;




    private PlayerControls controls = null;

    private Rigidbody rb;

    

    //Missil
    public GameObject misil;
    public Transform inst;
    private Camera mainCamera;
    public float misilCounter;
    public float misilCadency;
    private bool misilShot;


    private ChangeWeapon change;

    public Vector3 direction;
    public Vector3 finalPos;

    public float predictionTime;

    public bool godMode;

    //Tutorial
    public bool hasMoved;
    public bool hasJumped;
    public int numTuto;

    public bool isDead;

    public float waitPasos = 0f;
    public AudioSource pasos;
    public AudioSource tuercasSound;


    private bool changeDirection;
    private Vector3 currentDirection;
    private Vector3 newDirection;

    public bool killedArena;

    public AudioSource power1;
    public AudioSource power2;

    public GameObject tuercasUI;


    // Start is called before the first frame update
    void Awake()
    {
        hasMoved = false;
        hasJumped = false;
        isDead = false;
        numTuto = 0;
        shader = false;
        life = maxLife;
        shield = maxShield;
        totalLife = life + shield;
        playerLife.value = CalculateHealth();
        dashUI.fillAmount = CalculateDash();
        isGrounded = true;
        reciveDamage = false;

        controls = new PlayerControls();
        Cursor.lockState = CursorLockMode.Locked;

        mainCamera = Camera.main;
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

        rb = GetComponent<Rigidbody>();

        //movementSpeed = normalSpeed;
        //canDash = true;
        waitDash = timeToDash;



        misilCounter = 2;
        misilShot = true;

        killedArena = false;


        //arma =GameObject.FindGameObjectWithTag("Arma").GetComponent<Arma>();
        //metralleta = GameObject.FindGameObjectWithTag("Metralleta").GetComponent<Metralleta>();

    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (godMode == true)
        {
            //life = maxLife;
            waitDash = timeToDash;
            misilCounter = misilCadency;

        }

        waitPasos += Time.deltaTime;
        playerLife.value = CalculateHealth();
        dashUI.fillAmount = CalculateDash();
        hud.misilUI.fillAmount = hud.CalculateMisil();
        CheckGround();
        

        //totalLife = life + shield;
        //life = totalLife - shield;


        //waitUIL = waitDash;
        //waitUIR = waitDash;

        Move();

        if (direction.x == 0 && direction.z == 0)
        {
            movementSpeed = 0;

        }

        else if (direction.x != 0 || direction.z != 0)
        {
            currentDirection = direction;

            if (currentDirection != direction)
            {
                movementSpeed = 0;
                currentDirection = direction;
            }

            if (isGrounded == true)
            {
                normalSpeed = 10;
                movementSpeed += 0.5f;

                if (movementSpeed >= normalSpeed)
                {
                    movementSpeed = normalSpeed;

                }
            }

            else if (isGrounded == false)
            {
                normalSpeed = 7;
                movementSpeed += 0.5f;

                if (movementSpeed >= normalSpeed)
                {
                    movementSpeed = normalSpeed;
                }
            }

        }



        FixedUpdateJump();
        //FixedUpdateDash();

        if (direction.x != 0 || direction.z != 0)
        {
            hasMoved = true;
        }

        if (shield <= 0)
        {
            shield = 0;
            shader = true;
        }

        if (shield < maxShield)
        {
            cooldownShield += Time.deltaTime;
        }


        if (cooldownShield >= waitShield)
        {
            ChargeShield();
        }

        waitDash += Time.deltaTime;
        waitDash2 += Time.deltaTime;

        if (waitDash >= timeToDash)
        {
            waitDash = timeToDash;
        }


   

        if (dashes < 2)
        {

            if (waitDash >= timeToDash / 2 && waitDash < timeToDash)
            {
                dashes = 1;
            }

            else if (waitDash == timeToDash)
            {
                dashes = 2;
            }
        }



        //if (dashes >= 2)
        //{
        //    dashes = 2;
        //}

        
        if (canDash)
        {


            rb.AddForce(transform.TransformDirection(movement.normalized) * dashSpeed, ForceMode.VelocityChange);
            


            timeDashing += Time.deltaTime;


            if (timeDashing > dashDuration)
            {
                movementSpeed = normalSpeed;
                canDash = false;
                timeDashing = 0;
                waitDash = waitDash - timeToDash / 2;
                dashes--;

                if (dashes <= 0)
                {
                    dashes = 0;
                }

                //if (dashes == 1)
                //{
                //    waitDash = 0;
                //}

                else if (dashes == 0)
                {
                    //waitDash2 = 0;
                    twoDashes = true;
                }

                if (twoDashes)
                {
                    waitDash = 0;
                }
            }
        }

        //misil

        if (!misilShot)
        {
            misilCounter += Time.deltaTime;
            if (misilCounter == misilCadency)
            {
                misilCounter = misilCadency;
            }
            if (misilCounter >= misilCadency)
            {
                //hud.AlphaMisilNormal();  
                misilShot = true;

            }
        }

        if (life <= 0)
        {
            life = 0;
            Death();
        }

    

    }

    public float CalculateHealth()
    {
        return life / maxLife;
    }

    public float CalculateDash()
    {
        return waitDash / timeToDash; 
    }




    public void Jumping()
    {
        jump = true;
        if (numTuto == 1)
        {
            hasJumped = true;

        }

    }

    //public void Dash()
    //{

    //    dash = true;
    //}

    public void Move()
    {
        var movementInput = controls.Gameplay.Move.ReadValue<Vector2>();

        movement.x = movementInput.x;
        movement.z = movementInput.y;


        movement.Normalize();

        transform.Translate(movement * movementSpeed * Time.deltaTime);

        if (movement.x == 0 && movement.z == 0)
        {
            Andar.SetBool("Andar", false);
            pasos.Stop();
        }
        if (movement.x != 0 || movement.z != 0)
        {
            Andar.SetBool("Andar", true);

            if (waitPasos >= 0.5f && isGrounded == true && timeDashing == 0)
            {
                pasos.Play();
                waitPasos = 0;
            }

            //if (waitPasos < 1)
            //{
            //    pasos.Stop();
            //}

        }

        Debug.Log(movement.x);
        Debug.Log(movement.z);
        //Debug.Log("IsWalking");

        direction = movement;
    }

    Vector3 movement = Vector3.zero;
    public void FixedUpdateMove()
    {


        
        

    }

    private void FixedUpdateJump()
    {
        jumpCoolDown -= Time.deltaTime;

        if (jump)
        {



            if (isGrounded || jumpStairs.canJump == true)
            {
                jumpCoolDown = 0.2f;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
                Andar.SetTrigger("Jump");
            }

            jump = false;
        }

    }

    public void Dash()
    {

        if (waitDash >= timeToDash && dashes != 0 ||waitDash >= timeToDash / 2 && dashes != 0)
        {
            canDash = true;

        }



    }

    public void ShootMisil()
    {

        if (!misilShot)
        {
            return;
        }

        if (manager.pause == false)
        {
            //hud.AlphaMisilTransp();
            misilShot = false;
            misilCounter = 0;
            GameObject bulletObject = Instantiate(misil, inst.position, Quaternion.identity);
            bulletObject.transform.forward = mainCamera.transform.forward;
        }
       
    }

    public void GetDamage(float damage)
    {
        if (godMode == false)
        {
            life -= damage;
            cooldownShield = 0;
        }


    }

    public void ShieldDamage(float damage)
    {
        if (godMode == false)
        {
            shield -= damage;
            cooldownShield = 0;
            //reciveDamage = true;
            //StartCoroutine(WaitDamage());
        }

        else
        {
            shield = maxShield;
        }

    }

    public void ChargeShield()
    {
        shield += speedCharge * Time.deltaTime;

        if (shield >= maxShield)
        {
            shield = maxShield;
            cooldownShield = 0;
        }
    }

    public void SoundTuercas()
    {
        tuercasSound.Play();
    }

    public void ApparitionTuercas()
    {
        tuercasUI.SetActive(true);
        StartCoroutine(DisappearTuercas());
    }

    public void Death()
    {
        isDead = true;
        StartCoroutine(WaitDeath());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DesblokMetralleta")
        {
            change = GameObject.FindGameObjectWithTag("Holder").GetComponent<ChangeWeapon>();
            change.hasMetralleta = true;
            power1.Play();
        }

        if (other.tag == "Bloc")
        {
            life = 0;
        }

        if (other.tag == "Barranc")
        {
            life = 0;
        }

    }

    public void God()
    {
        godMode = !godMode;

        rb.useGravity = !rb.useGravity;
        rb.detectCollisions = !rb.detectCollisions;

        Collider godCol = GetComponent<Collider>();
        godCol.enabled = !godCol.enabled;
    }

    public void GodUp()
    {
        if (godMode == true)
            transform.Translate(0, 5 * Time.deltaTime, 0);
    }

    public void GodDown()
    {
        if (godMode == true)
            transform.Translate(0, -5 * Time.deltaTime, 0);
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Ground")
    //    {
    //        isGrounded = true;
    //    }
    //}

    //void OnCollisionExit(Collision other)
    //{
    //    if (other.gameObject.tag == "Ground")
    //    {
    //        isGrounded = false;
    //    }
    //}

    private void CheckGround()
    {

        Vector3 position = transform.position;
        int sign = 1;

        for (int i = 0; i < 3; i++)
        {
            position.x += i * 0.2f * sign;
            sign *= -1;


            ray = new Ray(position, Vector3.down);
            hit = new RaycastHit();

            //isGrounded = Physics.Raycast(ray, out hit, 1.1f, groundMask);
        }

        for (int i = 0; i < 3; i++)
        {
            position.z += i * 0.2f * sign;
            sign *= -1;


            ray = new Ray(position, Vector3.down);
            hit = new RaycastHit();

            //isGrounded = Physics.Raycast(ray, out hit, 1.1f, groundMask);
        }

        isGrounded = Physics.Raycast(ray, out hit, 0.2f, groundMask);
    }

 
    public void PlayPower()
    {
        power2.Play();
    }


    IEnumerator WaitDeath()
    {
        yield return new WaitForSeconds(2);
        manager.LoadDeath();
    }

    IEnumerator DisappearTuercas()
    {
        yield return new WaitForSeconds(2);
        tuercasUI.SetActive(false);
        StopCoroutine(DisappearTuercas());
    }

    //IEnumerator WaitDamage()
    //{
    //    yield return new WaitForSeconds(1);
    //    reciveDamage = false;
    //    cooldownShield = 0;
    //}

}
