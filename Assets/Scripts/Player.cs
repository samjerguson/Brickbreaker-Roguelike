using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ballSpawner;
    public GameObject ballPrefab;
    public int clonedBallsCount; // Number of balls to premake
    public int ballLoad = 1; //num balls to be instantiated at a time on x2. Higher number causes huge performance issues, keeping at at 1 for now.

    private List<GameObject> ballPool = new List<GameObject>();

private void Start()
    {
        //This could speed up the x2 by a lot, but when we use it the balls don't move. Prob commented in coroutine
        
        clonedBallsCount = CalculateMaxBalls(GameManager.defaultBricks, GameManager.times2Bricks, GameManager.plus2Bricks);
        print(clonedBallsCount);
        /*
        // Create a pool of ball objects
        for (int i = 0; i < clonedBallsCount; i++)
        {
            GameObject clonedBall = Instantiate(ballPrefab);
            clonedBall.SetActive(false);
            ballPool.Add(clonedBall);
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Maybe use switch instead?
        if (other.CompareTag("+2PowerUp"))
        {
            BallSpawner spawner = ballSpawner.GetComponent<BallSpawner>();
            if (spawner != null)
            {
                spawner.SpawnAndShootBall(45);
                
                spawner.SpawnAndShootBall(-45);
            }

            // Destroy the power-up
            Destroy(other.gameObject);
        }

        if (other.CompareTag("x2PowerUp"))
        {
            StartCoroutine(ActivateX2PowerUpCoroutine());

            // Destroy the power-up
            Destroy(other.gameObject);
        }
    }

    private IEnumerator ActivateX2PowerUpCoroutine()
    {
        /*
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            int temp = balls.Length;
            print(temp);
            if (ballPool.Count > 0)
            {
                GameObject clonedBall = ballPool[0];
                ballPool.RemoveAt(0);

                //clonedBall.SetActive(true);

                Vector3 ballPosition = ball.transform.position;
                Vector2 shootDirection = ball.GetComponent<Rigidbody2D>().velocity.normalized;
                float angleAdjustment = 45; // Modify this value as needed

                Vector2 newShootDirection = Quaternion.Euler(0f, 0f, angleAdjustment) * shootDirection;

                clonedBall.transform.position = ballPosition;

                Rigidbody2D clonedBallRigidbody = clonedBall.GetComponent<Rigidbody2D>();

                // Calculate the force needed to match the original ball's velocity
                float forceMagnitude = clonedBallRigidbody.mass * clonedBallRigidbody.gravityScale * ball.GetComponent<Rigidbody2D>().velocity.magnitude;

                // Apply the force to the cloned ball
                clonedBallRigidbody.AddForce(new Vector2(0,0) * 1000);

                GameManager.ballNum++;

                // Wait for one frame before processing the next ball
                
                yield return null;
            }
        }
        */

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        int i = 0;
        foreach (GameObject ball in balls)
        {
            if(ball != null)
            {
                Vector3 ballPosition = ball.transform.position;
                Vector2 shootDirection = ball.GetComponent<Rigidbody2D>().velocity.normalized;
                float angleAdjustment = 45;//Random.Range(-45, 45);

                Quaternion newRotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg + angleAdjustment);
                Vector2 newShootDirection = newRotation * Vector2.right;

                Instantiate(ballPrefab, ballPosition, Quaternion.identity).GetComponent<Rigidbody2D>().velocity = newShootDirection * ball.GetComponent<Rigidbody2D>().velocity.magnitude;
                GameManager.ballNum++;
                if(i%ballLoad == 0)
                    yield return null;
            }
        }
    }

    private int CalculateMaxBalls(int initialBalls, int numOfX2PowerUps, int numOfPlus2PowerUps)
    {
        // Add the contribution from +2 power-ups
        int totalBalls = initialBalls + (numOfPlus2PowerUps * 2);

        // Multiply by the growth factor from x2 power-ups
        totalBalls *= (int)Math.Pow(2, numOfX2PowerUps);

        return totalBalls;
    }

}
