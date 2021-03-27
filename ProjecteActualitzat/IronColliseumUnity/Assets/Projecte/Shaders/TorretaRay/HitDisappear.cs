using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDisappear : MonoBehaviour
{

    private Material alpha;
    public Renderer renderer;
    private float setAlpha;

    // Start is called before the first frame update
    void Start()
    {
        alpha = renderer.material;
        setAlpha = 0.5f;
        alpha.SetFloat("Vector1_CFFBA6D7", setAlpha);
    }

    // Update is called once per frame
    void Update()
    {
        setAlpha -= 0.3f * Time.deltaTime;
        alpha.SetFloat("Vector1_CFFBA6D7", setAlpha);

        if (setAlpha <= 0)
        {
            Destroy(alpha);
            Destroy(gameObject);
        }

    }
}
