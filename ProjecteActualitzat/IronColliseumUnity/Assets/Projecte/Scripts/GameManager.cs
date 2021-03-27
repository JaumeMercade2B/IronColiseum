using System.Collections;
using System.Collections.Generic;
//using System.Media;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    private HUD hud;
    public bool pause;

    public bool inventory;

    public bool openMenu;

    public Animator animator;

    public Animator win;
    public Animator dead;

    public bool enemyDead;

    public int enemyCount;

    public LevelManager levelManager;

    public bool isAnimatic;

    public GameObject skipButton;

    public bool skipped;

    private MenuManager menu;

    private Metralleta metralleta;
    private Lanzallamas lanza;
    private ChangeWeapon change;

    //public AudioSource pauseSound;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        change = GameObject.FindGameObjectWithTag("Holder").GetComponent<ChangeWeapon>();

        menu = GetComponent<MenuManager>();

        StartCoroutine(WaitLoad());
        //LockCursor();
        enemyCount = 0;
        skipped = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isAnimatic == false)
        {
            LockCursor();

        }

        if (pause || inventory)
        {
            openMenu = true;
        }

        //else
        //{
        //    openMenu = false;
        //}

     
        if (openMenu)
        {
            Time.timeScale = 0;
            UnlockCursor();
        }
    }

    public void Pause()
    {
        if (inventory == false)
        {
            //pauseSound.Play();
            pause = !pause;
            hud.OpenPausePanel(pause);
        }


        if (pause)
        {
            if (change.ReturnCurrent() == 1)
            {
                metralleta = GameObject.FindGameObjectWithTag("Metralleta").GetComponent<Metralleta>();
                metralleta.sound.Stop();
            }

            if (change.ReturnCurrent() == 2)
            {
                lanza = GameObject.FindGameObjectWithTag("Lanzallamas").GetComponent<Lanzallamas>();
                lanza.hold.Stop();
            }

            Time.timeScale = 0;
            UnlockCursor();
            openMenu = true;
        }

        else
        {
            Time.timeScale = 1;
            LockCursor();
            openMenu = false;

        }

    }

    public void Inventory()
    {

        if (pause == false)
        {
            inventory = !inventory;
            hud.OpenInventoryPanel(inventory);
        }
 

        if (inventory)
        {
            Time.timeScale = 0;
            UnlockCursor();
            openMenu = true;
        }

        else
        {
            Time.timeScale = 1;
            LockCursor();
            openMenu = false;

        }
    }

    public void LoadDeath()
    {
        StartCoroutine(WaitLoadDeath());
        UnlockCursor();
    }

    public void LoadVictory()
    {
        StartCoroutine(WaitLoadVictory());
        UnlockCursor();
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SkipCinematic()
    {
        StopAllCoroutines();

        levelManager.canAct = true;
        Time.timeScale = 1;
        isAnimatic = false;
        LockCursor();
        hud.InterficieOn();
        skipButton.SetActive(false);
        skipped = true;
        menu.SetContinui();
    }

    IEnumerator WaitLoadDeath()
    {
        dead.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        UnlockCursor();
        SceneManager.LoadScene("Death");
    }

    IEnumerator WaitLoadVictory()
    {
        win.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        UnlockCursor();
        SceneManager.LoadScene("Victory");
    }

    IEnumerator WaitLoad()
    {
        skipButton.SetActive(true);
        isAnimatic = true;
        hud.InterficieOff();
        UnlockCursor();
        //Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        animator.SetTrigger("End");
        yield return new WaitForSecondsRealtime(85);
        levelManager.canAct = true;
        Time.timeScale = 1;
        isAnimatic = false;
        LockCursor();
        hud.InterficieOn();
        skipButton.SetActive(false);
    }
}
