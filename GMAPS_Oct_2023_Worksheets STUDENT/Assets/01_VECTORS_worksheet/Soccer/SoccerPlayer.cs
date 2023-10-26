using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

            DrawVectors();

            
            SoccerPlayer target = FindClosestPlayerDot();
            target.GetComponent<Renderer>().material.color = Color.green;

            foreach (SoccerPlayer other in OtherPlayers.Where(t => t != target))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
            
        }

    }

    private void Start()
    {
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();
    }

    float Magnitude(Vector3 vector)
    {
        float mag = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        return mag;
    }

    Vector3 Normalise(Vector3 vector)
    {
        float mag = Magnitude(vector);
        return new(vector.x / mag, vector.y / mag, vector.z / mag);
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        Vector3 normVectA = Normalise(vectorA);
        Vector3 normVectB = Normalise(vectorB);

        // normalize the vectors then calculate the dot
        return ((normVectA.x * normVectB.x) + (normVectA.y * normVectB.y) + (normVectA.z * normVectB.z));
    }

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;
        for (int i = 0; i < OtherPlayers.Length; i++)
        {
            Vector3 directionToPlayer = OtherPlayers[i].transform.position - transform.position;

            //find the angle from this player's forward to the target player
            float dotProduct = Dot(transform.forward, directionToPlayer);
            float angle = Mathf.Acos(dotProduct);
            angle *= Mathf.Rad2Deg;
            if (angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }

        return closest;
    }

    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            //find direction from this player to the other
            Vector3 dir = other.transform.position - transform.position;
            Debug.DrawRay(transform.position, dir, Color.black);
        }
    }

    void FindMinimum()
    {
        float minValue = Mathf.Infinity;
        for (int i = 0; i < OtherPlayers.Length; i++)
        {
            float value = Random.Range(5, 20);
            if (value < minValue)
                minValue = value;
        }
        Debug.Log(minValue);
    }
}


