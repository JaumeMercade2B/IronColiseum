using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextWriter : MonoBehaviour
{

    [SerializeField] private AutomaticWrite automaticWrite;
    public TextMeshProUGUI text;
    public string textWrite;
    public float speed;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Start()
    {
        //automaticWrite.AddWritter(text, textWrite, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
