using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutomaticWrite : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string textToWrite;
    public float timePerCharacter;
    public float timer;
    private int characterIndex;
    public TeclasScript sound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                
                characterIndex++;
                text.text = textToWrite.Substring(0, characterIndex);
                sound.Sound();
                timer += timePerCharacter;
                if (characterIndex >= textToWrite.Length)
                {
                    text = null;
                    return;
                }
            }
        }
    }

    //public void AddWritter(TextMeshProUGUI text, string textToWrite, float timePerCharacter)
    //{
    //    characterIndex = 0;
    //    this.text = text;
    //    this.textToWrite = textToWrite;
    //    this.timePerCharacter = timePerCharacter;
    //}
}
