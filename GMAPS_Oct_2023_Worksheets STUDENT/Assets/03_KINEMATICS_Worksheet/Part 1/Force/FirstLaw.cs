using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        //get the rigidbody of the object
        rb = GetComponent<Rigidbody>();

        //apply the force specified
        rb.AddForce(force);
     }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

