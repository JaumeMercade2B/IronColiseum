using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{

    public GameObject Slider;
    public Animator animator;
    [SerializeField] private bool optionsLoaded;

    public GameObject options;


    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
 
    }
    public void LoadGame()
    {
        StartCoroutine (WaitLoadGame());
    }

    public void Menu()
    {
        
        StartCoroutine(WaitLoadMenu());

    }

    public void Options()
    {

        StartCoroutine (WaitLoadOptions());

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
        options.SetActive(true);
        animator.SetTrigger("End");
        //yield return new WaitForSecondsRealtime(1);


    }

    IEnumerator WaitCloseOptions()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        options.SetActive(false);
        animator.SetTrigger("End");

    }

    IEnumerator WaitLoadExit()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        Application.Quit();
    }

}
