using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class VictoryDeadMenu : MonoBehaviour
{


    public Animator animator;

    private GameManager manager;
    //private HUD hud;




    public EventSystem sistemMenu;

    public GameObject game;


    public DetectInput input;
    private void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

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
        if (input.gamepadActive)
        {
            sistemMenu.firstSelectedGameObject = game;

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

    //public void Options()
    //{

    //    StartCoroutine(WaitLoadOptions());


    //}

    //public void CloseOptions()
    //{

    //    StartCoroutine(WaitCloseOptions());


    //}

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

    //IEnumerator WaitLoadOptions()
    //{
    //    animator.SetTrigger("Start");
    //    yield return new WaitForSecondsRealtime(1);       
    //    options.SetActive(true);
    //    sistemMenu.SetSelectedGameObject(optionsButton);
    //    animator.SetTrigger("End");
    //    openOptions = true;
        
        
    //    //yield return new WaitForSecondsRealtime(1);


    //}

    //IEnumerator WaitCloseOptions()
    //{
    //    animator.SetTrigger("Start");
    //    yield return new WaitForSecondsRealtime(1);
    //    mainButtons.SetActive(true);
    //    sistemMenu.SetSelectedGameObject(game);
    //    animator.SetTrigger("End");
    //    openOptions = false;
        
       

    //}

    IEnumerator WaitLoadExit()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        Application.Quit();
    }

}

