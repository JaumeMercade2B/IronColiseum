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

    public bool enemyDead;

    public int enemyCount;

    //public AudioSource pauseSound;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        StartCoroutine(WaitLoad());
        LockCursor();
        enemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        LockCursor();
        
        if (pause || inventory)
        {
            openMenu = true;
        }

        else
        {
            openMenu = false;
        }

     
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

    IEnumerator WaitLoadDeath()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        UnlockCursor();
        SceneManager.LoadScene("Death");
    }

    IEnumerator WaitLoadVictory()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        UnlockCursor();
        SceneManager.LoadScene("Victory");
    }

    IEnumerator WaitLoad()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        animator.SetTrigger("End");
        Time.timeScale = 1;
        
    }
}
