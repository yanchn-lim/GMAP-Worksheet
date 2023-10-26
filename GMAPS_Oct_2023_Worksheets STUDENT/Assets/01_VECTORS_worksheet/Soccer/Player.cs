using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsCaptain = true;
    public Player OtherPlayer;

    float Magnitude(Vector3 vector)
    {
        float mag = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        return mag;
    }

    Vector3 Normalise(Vector3 vector)
    {
        float mag = Magnitude(vector);
        return new(vector.x / mag, vector.y / mag,vector.z/mag);
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        Vector3 normVectA = Normalise(vectorA);
        Vector3 normVectB = Normalise(vectorB);

        // normalize the vectors then calculate the dot
        return ((normVectA.x * normVectB.x) + (normVectA.y * normVectB.y) + (normVectA.z * normVectB.z));
    }

    float AngleToPlayer()
    {
        //get direction from this player to the target player
        Vector3 directionToPlayer = OtherPlayer.transform.position - transform.position;

        //find the angle from this player's forward to the target player
        float dotProduct = Dot(transform.forward, directionToPlayer);
        float angleRadian = Mathf.Acos(dotProduct);
        float angleDegree = angleRadian * Mathf.Rad2Deg;

        //vector subtraction to find the direction towards the player
        DebugExtension.DebugArrow(transform.position, directionToPlayer, Color.black);

        //captain's forward
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);

        return angleDegree;
    }

    void Update()
    {
        if (IsCaptain)
        {
            //get angle from captain to player
            float angle = AngleToPlayer();
            Debug.Log($"angle : {angle}");
        }
    }
}
