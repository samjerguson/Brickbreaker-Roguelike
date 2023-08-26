using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollision : MonoBehaviour
{
    public GameObject plus2Prefab;
    public GameObject times2Prefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroys brick if ball collides with it
        if (collision.gameObject.CompareTag("Brick")) //default brick
        {
            // Destroy the collided object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("+2PowerUp"))
        {
            // Destroy the collided object and spawn given powerup
            Destroy(collision.gameObject);
            Instantiate(plus2Prefab, collision.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("x2PowerUp"))
        {
            // Destroy the collided object and spawn given powerup
            Destroy(collision.gameObject);
            Instantiate(times2Prefab, collision.transform.position, Quaternion.identity);
        }

        // Destroys ball if it hits Lost zone
        if (collision.gameObject.CompareTag("Lost"))
        {
            Destroy(gameObject);
            GameManager.ballNum--;
        }
    }
}
