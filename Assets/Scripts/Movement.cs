using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Player/Character speed and direction
    public float WalkSpeed = 1f;
    private float isRight = 1f;

    //Gravity
    public float gravity = 10f;
    public float jumpForce;

    Vector3 moveDirection;

    void Update()
    {
        AutoWalk();
        Jump();
    }

    //Character movement  
    private void AutoWalk()
    {
        Vector3 moveDirection = transform.position;

        moveDirection.x += WalkSpeed * isRight;

        transform.position = moveDirection;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Trigger")
        {
            Debug.Log("Hit");
            isRight *= -1f;

            transform.Rotate(0, 180, 0);
        }
    }

    //Player jump
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }

}
