using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a tag "Brick"
        if (collision.gameObject.CompareTag("Brick"))
        {
            // Destroy the collided object
            Destroy(collision.gameObject);
        }

        // Check if the collided object has a tag "Brick"
        if (collision.gameObject.CompareTag("Floor"))
        {
            // Game over (Add code at some point)
            SceneManager.LoadScene("GameOver");
        }
    }
}
