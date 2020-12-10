using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Transitions : MonoBehaviour
{
    public Animator animator;

    private Scene currentScene;
    private string sceneName;

    private Scene options;
    private string optionsScene;

    public bool optionsOpen;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;

        options = SceneManager.GetSceneByName("Options");

        StartCoroutine(WaitLoad());
    }

    // Update is called once per frame
    void Update()
    {

        if (sceneName == "Options")
        {
            optionsOpen = true;
        }

        else
        {
            optionsOpen = false;
        }

        Debug.Log(sceneName);
    }

    IEnumerator Wait()
    {
        yield return new WaitUntil(() => optionsOpen = false);
        animator.SetTrigger("End");
    }

    IEnumerator WaitLoad()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        animator.SetTrigger("End");
        Time.timeScale = 1;

    }

}
