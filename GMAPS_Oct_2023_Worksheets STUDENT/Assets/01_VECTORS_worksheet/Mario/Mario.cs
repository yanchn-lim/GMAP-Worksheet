using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //getting the directions for each forces
        gravityDir = planet.position - transform.position;
        moveDir = new(gravityDir.y, -gravityDir.x);

        //flipping the move diretion for mario to make him move clockwise
        moveDir = moveDir.normalized * -1f;
        rb.AddForce(moveDir * force);

        //normalize gravity and apply gravity force
        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(Vector3.right,moveDir, Vector3.forward);
        rb.MoveRotation(Quaternion.Euler(0,0,angle));

        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
    }
}


