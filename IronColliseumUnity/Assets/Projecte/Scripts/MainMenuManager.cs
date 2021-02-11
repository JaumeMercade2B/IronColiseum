using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuManager : MonoBehaviour
{

    public GameObject Slider;
    public Animator animator;
    [SerializeField] private bool optionsLoaded;
    private GameManager manager;
    private HUD hud;

    public GameObject options;
    public bool openOptions;

    public GameObject mainButtons;

    public GameObject logo;

    public GameObject title;

    public EventSystem sistemMenu;

    public GameObject game;

    public GameObject optionsButton; 

    public DetectInput input;
    private void Start()
    {
        Time.timeScale = 1;

        openOptions = false;

        //if (input.gamepadActive)
        //    sistemMenu.firstSelectedGameObject = game;

        //else
        //{
        //    sistemMenu.firstSelectedGameObject = null;

        //}

        if (input.gamepadActive == true)
        {
            sistemMenu.SetSelectedGameObject(game);

        }

    }

    private void Update()
    {
        if (input.gamepadActive && openOptions == false)
        {
            sistemMenu.firstSelectedGameObject = game;

        }

        else if (input.gamepadActive && openOptions == true)
        {
            
            sistemMenu.firstSelectedGameObject = optionsButton;
            

        }

        else if (input.gamepadActive == false)
        {
            sistemMenu.firstSelectedGameObject = null;
        }
    }
    public void LoadGame()
    {
        if (input.gamepadActive == true)
        {
            sistemMenu.SetSelectedGameObject(game);

        }

        StartCoroutine(WaitLoadGame());
    }

    public void Menu()
    {

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
        mainButtons.SetActive(false);
        logo.SetActive(false);
        title.SetActive(false);

        options.SetActive(true);
        sistemMenu.SetSelectedGameObject(optionsButton);
        animator.SetTrigger("End");
        openOptions = true;
        
        
        //yield return new WaitForSecondsRealtime(1);


    }

    IEnumerator WaitCloseOptions()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        options.SetActive(false);

        mainButtons.SetActive(true);
        logo.SetActive(true);
        title.SetActive(true);


        sistemMenu.SetSelectedGameObject(game);
        animator.SetTrigger("End");
        openOptions = false;
        
       

    }

    IEnumerator WaitLoadExit()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        Application.Quit();
    }

}
