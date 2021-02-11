using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Easings : MonoBehaviour
{
    SpriteRenderer renderer;

    public Transform title;

    public float delay;

    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();


        DOTween.Sequence().
     Insert(0,
         DOTween.Sequence().
             Append(title.DOScale(new Vector3(scale, scale, scale), 1f).SetDelay(delay).SetEase(Ease.OutExpo)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
