using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckThePoliceBehaviour : MonoBehaviour
{

    public float life;
    public float maxLife;

    public Renderer enemyRender;
    public float disolve;

    public bool dead;

    private Material dissolveMat;

    private OleadasTalller oleadas;
    public bool canCount;

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        disolve = 1;
        dissolveMat = enemyRender.material;
        dissolveMat.SetFloat("Vector1_283E90B", disolve);
        dead = false;

        oleadas = GameObject.FindGameObjectWithTag("SpawnPolice").GetComponent<OleadasTalller>();
        canCount = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (dead == false)
        {
            if (disolve >= 0)
            {
                disolve -= 0.5f * Time.deltaTime;
                dissolveMat.SetFloat("Vector1_283E90B", disolve);

            }

            if (disolve <= 0)
            {
                disolve = 0;
                dissolveMat.SetFloat("Vector1_283E90B", disolve);

            }
        }

        if (life <= 0)
        {
            Dead();
        }
    }

    public void GetDamage(float damage)
    {
        life -= damage;
    }

    private void Dead()
    {

        if (canCount == true)
        {
            oleadas.deadPolice++;
            canCount = false;
        }
        dead = true;
        Disappear();
        dissolveMat.SetFloat("Vector1_283E90B", disolve);

        if (disolve >= 1)
        {

            
            Destroy(gameObject, 0.5f);

        }
    }

    public void Appear()
    {
        disolve -= 0.3f * Time.deltaTime;
    }

    public void Disappear()
    {
        disolve += 0.5f * Time.deltaTime;

    }

    private void OnDestroy()
    {
        Destroy(dissolveMat);
    }
}
