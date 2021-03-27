using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class DisolveHit : MonoBehaviour
{
    private DecalProjector decal;

    private 
    // Start is called before the first frame update
    void Start()
    {
        decal = GetComponent<DecalProjector>();
    }

    // Update is called once per frame
    void Update()
    {
        decal.fadeFactor -= Time.deltaTime;

        if (decal.fadeFactor <= 0)
        {
            Destroy(gameObject);
        }
    }
}
