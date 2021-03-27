using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arma3Desbloc : MonoBehaviour
{

    public float rotateSpeed;

    private GameManager manager;
    private ChangeWeapon change;
    private FPSController player;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        change = GameObject.FindGameObjectWithTag("Holder").GetComponent<ChangeWeapon>();

    }

    // Update is called once per frame
    void Update()
    {

        if (manager.pause == false)
        {
            gameObject.transform.Rotate(new Vector3(0, rotateSpeed, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
            player.PlayPower();
            change.hasArma3 = true;
            Destroy(gameObject);
        }
    }

}
