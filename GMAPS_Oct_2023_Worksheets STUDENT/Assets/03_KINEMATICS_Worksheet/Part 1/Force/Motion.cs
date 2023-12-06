using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        //get the time delta
        float dt = Time.deltaTime;
        
        //get the change in displacement from each force direction
        float dx = Velocity.x * dt;
        float dy = Velocity.y * dt;
        float dz = Velocity.z * dt;

        //apply the displacement using unity's Translate() function
        transform.Translate(new Vector3(dx,dy,dz));
    }
}
