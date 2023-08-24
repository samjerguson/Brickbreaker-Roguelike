using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public float shootSpeed = 5f;
    public float shootAngle = 45f; // The angle at which the ball will be shot (in degrees)

    private void Start()
    {
        SpawnAndShootBall();
    }

    private void SpawnAndShootBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        
        if (rb != null)
        {
            // Calculate the shoot direction based on the shoot angle
            Vector2 shootDirection = Quaternion.Euler(0, 0, shootAngle) * Vector2.up;

            // Apply the calculated direction and speed to the ball
            rb.AddForce (shootDirection.normalized * shootSpeed);
        }
        else
        {
            Debug.LogWarning("The spawned object does not have a Rigidbody2D component.");
        }
    }
}