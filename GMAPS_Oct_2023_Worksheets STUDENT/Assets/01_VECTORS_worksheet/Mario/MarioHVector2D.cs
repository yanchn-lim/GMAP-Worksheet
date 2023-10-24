using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private HVector2D up;
    private Rigidbody2D rb;

    float dot;
    float angle;
    float prevAngle = Mathf.Infinity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        up = new(-Vector3.up);
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);

        moveDir = moveDir.normalized * -1f;
        rb.AddForce(moveDir.ToUnityVector3() * force);

        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm.ToUnityVector3() * gravityStrength);

        dot = up.DotProduct(gravityDir);
        angle = up.FindAngle(dot);
        if (angle > prevAngle)
        {
            Debug.Log("1");
            rb.MoveRotation(Quaternion.Euler(0, 0, -angle));
        }
        else if (angle < prevAngle)
        {
            Debug.Log("2");
            rb.MoveRotation(Quaternion.Euler(0, 0, angle));
        }
        prevAngle = angle;

        DebugExtension.DebugArrow(transform.position, gravityDir.ToUnityVector3(), Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir.ToUnityVector3(), Color.blue);
    }
}
