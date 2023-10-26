using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public int NumOfPlayers =  8;
    public float distanceFromCenter = 5;
    public Transform captain;
    public GameObject playerPrefab;
    Vector3 forward;

    void Awake()
    {
        forward = captain.forward;
        float angleIncrement = 360 / NumOfPlayers;
        //use angle and magnitude to find the position to spawn the player
        for (int i = 0; i < NumOfPlayers; i++)
        {
            float angle = i * angleIncrement * Mathf.Deg2Rad;

            Vector3 spawnLocation = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * distanceFromCenter;
            spawnLocation += captain.position;
            Instantiate(playerPrefab, spawnLocation, Quaternion.identity).name = $"player_{i}";
        }
    }
}
