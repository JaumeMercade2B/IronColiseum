using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{

    public GameObject timelineInicial;
    private GameManager manager;
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        timelineInicial.SetActive(false);
        StartCoroutine(TimelineInicial());
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.skipped == true)
        {
            StopAllCoroutines();
            timelineInicial.SetActive(false);
            manager.skipped = false;
            transition.SetTrigger("Start");
        }
    }

    public void ActiveInicial()
    {
        timelineInicial.SetActive(true);
    }

    public IEnumerator TimelineInicial()
    {
        yield return new WaitForSecondsRealtime(1f);
        ActiveInicial();
        yield return new WaitForSecondsRealtime(75f);
        timelineInicial.SetActive(false);

    }
}
