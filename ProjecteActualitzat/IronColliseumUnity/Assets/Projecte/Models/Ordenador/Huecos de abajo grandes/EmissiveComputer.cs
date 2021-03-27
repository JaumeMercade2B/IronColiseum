using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissiveComputer : MonoBehaviour
{
    public Material emissive;
    //private Renderer renderer;

    public float intensity;
    public bool sube;
    


    // Start is called before the first frame update
    void Start()
    {
        //renderer = GetComponent<Renderer>();
        //emissive = renderer.material;
        emissive.EnableKeyword("_EMISSION");

        StartCoroutine(Emissive());
    }

    // Update is called once per frame
    void Update()
    {
        emissive.SetColor("_EmissiveColor", Color.blue * intensity);

        if (sube == true)
        {
            intensity += Time.deltaTime * 50;
        }

        else if (sube == false)
        {
            intensity -= Time.deltaTime * 50;
        }
    }

    IEnumerator Emissive()
    {
        sube = true;
        
        yield return new WaitForSeconds(3);
        sube = false;
        
        yield return new WaitForSeconds(3);
        StartCoroutine(Emissive());

    }
}
