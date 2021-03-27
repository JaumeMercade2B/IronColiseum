using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class SettingsMenu : MonoBehaviour
{

    static string music_PPrefsTag = "Music";
    static string vfx_PPrefsTag = "vfx";
    static string brightness_PPrefsTag = "Brightness";

    public AudioMixer mixer;
    public Slider slider;
    public Slider sliderVFX;


    public Dropdown quality;

    const string prefName = "optionvalue";
    const string resName = "resolutionoption";

    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    public Toggle fullscreen;

    private bool isFullscreen = false;

    [SerializeField] Slider sliBrightness;

    ColorAdjustments colorAdjustments;

    [SerializeField] Volume volume;

    private int screenInt;
    private void Awake()
    {

        screenInt = PlayerPrefs.GetInt("toglestate");

        if (screenInt == 1)
        {
            isFullscreen = true;
            fullscreen.isOn = true;
        }

        else
        {
            fullscreen.isOn = false;
        }

        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resName, resolutionDropdown.value);
            PlayerPrefs.Save();

        }));

        quality.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, quality.value);
            PlayerPrefs.Save();
        }));
    }
    public void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);

        sliderVFX.value = PlayerPrefs.GetFloat(vfx_PPrefsTag, 0.5f);
        slider.value = PlayerPrefs.GetFloat(music_PPrefsTag, 0.5f);
        sliBrightness.value = PlayerPrefs.GetFloat(brightness_PPrefsTag, 0.75f);

        //slider.value = PlayerPrefs.GetFloat("MVolume", 1f);
        //mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MVolume"));

        //sliderVFX.value = PlayerPrefs.GetFloat("MVolume", 1f);
        //mixer.SetFloat("VFXVolume", PlayerPrefs.GetFloat("MVolume"));

        quality.value = PlayerPrefs.GetInt(prefName, 3);


        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int CurrentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = CurrentResolutionIndex;
        resolutionDropdown.RefreshShownValue();


    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat(music_PPrefsTag, volume);
        mixer.SetFloat("MusicVolume", volume);

    }

    public void SetVolumeVFX(float volume)
    {
        PlayerPrefs.SetFloat(vfx_PPrefsTag, volume);
        mixer.SetFloat("VFXVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];


        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        if (isFullscreen == false)
        {
            PlayerPrefs.SetInt("toglestate", 0);
        }

        else
        {
            isFullscreen = true;
            PlayerPrefs.SetInt("toglestate", 1);

        }
    }

    public void OnSliGammaValue(float newValue)
    {
        PlayerPrefs.SetFloat(brightness_PPrefsTag, newValue);
        colorAdjustments.postExposure.value = NormalizedToRange(newValue, -5f, 5f);
    }

    public float NormalizedToRange(float value, float min, float max)
    {
        float range = max - min;
        float rangedValue = min + (value * range);

        return rangedValue;
    }

    public static float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;

        return dB;
    }

    public static float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20.0f);

        return linear;
    }

}
