using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public float moveSpeed = 3f; // Constant speed

    private void Update()
    {
        // Calculate the new position based on the current position and time
        float newPositionX = transform.position.x;
        float newPositionY = transform.position.y - moveSpeed * Time.deltaTime;
        

        // Set the new position
        transform.position = new Vector2(newPositionX, newPositionY);
    }
}
