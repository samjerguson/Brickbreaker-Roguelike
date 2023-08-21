using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 private bool isDragging = false;
    private Vector3 offset;
    public Transform player; // Renamed variable name
    public Camera mainCamera;
    public float buffer = 0.1f;

    private void OnMouseDown()
    {
        offset = player.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.y = player.position.y;

            float playerWidth = player.GetComponent<Renderer>().bounds.size.x;

            float bufferWidth = playerWidth * buffer;

            float clampXMin = mainCamera.ViewportToWorldPoint(Vector3.zero).x + playerWidth / 2 + bufferWidth;
            float clampXMax = mainCamera.ViewportToWorldPoint(Vector3.right).x - playerWidth / 2 - bufferWidth;

            newPosition.x = Mathf.Clamp(newPosition.x, clampXMin, clampXMax);

            player.position = newPosition;
        }
    }
}
