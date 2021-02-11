using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class MenuManager : MonoBehaviour
{

    public GameObject Slider;
    public Animator animator;
    [SerializeField] private bool optionsLoaded;
    private GameManager manager;
    private HUD hud;

    public GameObject options;
    public bool openOptions;

    public DetectInput input;

    public GameObject continui;
    public GameObject optionsButton;

    public EventSystem sistemMenu;

    private void Start()
    {
        Time.timeScale = 1;

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

        if (input.gamepadActive == true)
        {
            sistemMenu.SetSelectedGameObject(continui);

        }
     
        openOptions = false;

    }

    private void Update()
    {
        if (openOptions)
        {
            manager.pause = true;
        }

        if (input.gamepadActive && openOptions == false)
            sistemMenu.firstSelectedGameObject = continui;

        else if (input.gamepadActive && openOptions == true)
        {

            sistemMenu.firstSelectedGameObject = optionsButton;


        }
    }
    public void LoadGame()
    {
        StartCoroutine(WaitLoadGame());
    }

    public void Menu()
    {
        if (input.gamepadActive == true)
        {
            sistemMenu.SetSelectedGameObject(continui);

        }
        Time.timeScale = 0;
        hud.OpenPausePanel(false);
        openOptions = false;
        //sistemMenu.SetSelectedGameObject(null);
        //sistemMenu.firstSelectedGameObject = null;
        StartCoroutine(WaitLoadMenu());

    }

    public void Options()
    {

        StartCoroutine(WaitLoadOptions());

    }

    public void CloseOptions()
    {

        StartCoroutine(WaitCloseOptions());
    }

    public void ExitGame()
    {

        StartCoroutine(WaitLoadExit());

    }

    public void Victory()
    {
        StartCoroutine(LoadVictory());
    }

    public void Dead()
    {
        StartCoroutine(LoadDead());
    }

    IEnumerator WaitLoadGame()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("Escenari1");

    }

    IEnumerator WaitLoadMenu()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator WaitLoadOptions()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        hud.OpenPausePanel(false);
        options.SetActive(true);
        sistemMenu.SetSelectedGameObject(optionsButton);
        animator.SetTrigger("End");
        openOptions = true;
        manager.pause = true;
        hud.OpenPausePanel(false);
        //yield return new WaitForSecondsRealtime(1);


    }

    IEnumerator WaitCloseOptions()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        options.SetActive(false);
        hud.OpenPausePanel(true);
        sistemMenu.SetSelectedGameObject(continui);
        animator.SetTrigger("End");
        openOptions = false;
        manager.pause = true;
        hud.OpenPausePanel(true);

    }

    IEnumerator WaitLoadExit()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        Application.Quit();
    }

    IEnumerator LoadVictory()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("Victory");
    }

    IEnumerator LoadDead()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("Death");
    }

}
