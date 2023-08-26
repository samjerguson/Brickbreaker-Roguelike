using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform playerTransform;
    public float shootSpeed = 500f;
    public float shootAngle = 0f; // The angle at which the ball will be shot (in degrees)
    public float spawnOffset;

    private Vector2 spawnPoint;

    private void Start()
    {
        spawnPoint = new Vector2(playerTransform.position.x, playerTransform.position.y + spawnOffset);
        SpawnAndShootBall(shootAngle);
    }

    private void Update()
    {
        spawnPoint = new Vector2(playerTransform.position.x, playerTransform.position.y + spawnOffset);
    }

    public  void SpawnAndShootBall(float angle)
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint, Quaternion.identity);
        GameManager.ballNum++;
        
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        
        if (rb != null)
        {
            // Calculate the shoot direction based on the shoot angle
            Vector2 shootDirection = Quaternion.Euler(0, 0, angle) * Vector2.up;

            // Apply the calculated direction and speed to the ball
            rb.AddForce (shootDirection.normalized * shootSpeed);
        }
        else
        {
            Debug.LogWarning("The spawned object does not have a Rigidbody2D component.");
        }
    }
}