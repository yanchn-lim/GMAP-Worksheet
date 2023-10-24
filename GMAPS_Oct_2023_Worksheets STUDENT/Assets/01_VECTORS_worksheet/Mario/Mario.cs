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
        gravityDir = planet.position - transform.position;

        moveDir = new(gravityDir.y, -gravityDir.x);
        moveDir = moveDir.normalized * -1f;

        rb.AddForce(moveDir * force);
        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(-Vector3.up,gravityNorm, Vector3.forward);
        Debug.Log(angle);
        rb.MoveRotation(Quaternion.Euler(0,0,angle));
        DebugExtension.DebugArrow(transform.position, Vector3.up, Color.yellow);
        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
    }
}


