using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
