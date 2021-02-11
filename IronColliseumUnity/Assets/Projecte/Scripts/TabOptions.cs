using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabOptions : MonoBehaviour
{
    public GameObject GeneralPanel;
    public GameObject ScreenPanel;
    public GameObject ScreenButton;


    // Start is called before the first frame update
    void Start()
    {
        GeneralPanel.SetActive(true);
        ScreenPanel.SetActive(false);
        ScreenButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenGeneralPanel()
    {
        GeneralPanel.SetActive(true);
        ScreenPanel.SetActive(false);
    }

    public void OpenScrenPanel()
    {
        ScreenPanel.SetActive(true);
        GeneralPanel.SetActive(false);
    }
}
