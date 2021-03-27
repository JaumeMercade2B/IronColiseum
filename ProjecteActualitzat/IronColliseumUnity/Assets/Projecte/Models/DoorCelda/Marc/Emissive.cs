using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emissive : MonoBehaviour
{
    private Material emissive;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {

        renderer = GetComponent<Renderer>();
        emissive = renderer.material;
        emissive.EnableKeyword("_EMISSION");

        emissive.SetColor("_EmissiveColor", Color.red * 200f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Green()
    {
        emissive.SetColor("_EmissiveColor", Color.white * 200f);
    }

    public void Red()
    {
        emissive.SetColor("_EmissiveColor", Color.red * 200f);
    }

}
