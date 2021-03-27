using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExp : MonoBehaviour
{

    public float explosionForce;
    public float explosionRadius;
    private PoliceTaller enemigo;
    private Rigidbody enemyRB;

    public float damage;

    public bool isEnemy;
    public LayerMask whatIsPolice;

    private Renderer mesh;

    public Collider col;
    public Collider col2;

    public GameObject explosion;

    private AudioSource explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<Renderer>();
        explosionSound = GetComponent<AudioSource>();

        explosion.SetActive(false);
        mesh.enabled = true;

        col.enabled = true;
        col2.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider enemy in hits)
        {

            if (enemy.GetComponent<PoliceTaller>() != null)
            {
                enemigo = enemy.GetComponent<PoliceTaller>();
                enemyRB = enemy.GetComponent<Rigidbody>();
                enemyRB.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                enemyRB.AddForce(new Vector3(0, 25, 0), ForceMode.Impulse);
                enemigo.GetDamage(damage);

            }
        }

        explosion.SetActive(true);
        mesh.enabled = false;
        col.enabled = false;
        col2.enabled = false;
        explosionSound.Play();

        Destroy(gameObject, 3f);
    }
}
