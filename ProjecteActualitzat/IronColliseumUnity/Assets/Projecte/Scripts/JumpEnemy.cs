using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : MonoBehaviour
{

    public float jumpForce;
    [SerializeField] private bool canJump;
    [SerializeField] private bool isGrounded;
    [SerializeField] private int timeBetweenJumps;
    [SerializeField] private float timeToJump;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        timeBetweenJumps = Random.Range(5, 25);
        rb = GetComponentInChildren<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        timeToJump += Time.deltaTime;

        if (timeToJump >= timeBetweenJumps)
        {
            Jump();
        }
    }

    private void Jump()
    {

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
        StartCoroutine(waitJump());
    }

    IEnumerator waitJump()
    {

        yield return new WaitForSeconds(3);
        timeBetweenJumps = Random.Range(5, 25);
        timeToJump = 0;
        yield return new WaitForSeconds(0);

    }
}
