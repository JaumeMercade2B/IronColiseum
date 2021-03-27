using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerPrefs.SetFloat("MVolume", 1f);
        mixer.SetFloat("Volume", PlayerPrefs.GetFloat("MVolume"));
    }

    private void Update()
    {
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("MainMenu");
    }
}
