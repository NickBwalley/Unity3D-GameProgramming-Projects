using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player's position to the camera's position
    public float sensitivity = 0f; // Mouse rotation sensitivity
    public float minYAngle = -30.0f; // Minimum vertical rotation angle
    public float maxYAngle = 80.0f; // Maximum vertical rotation angle

    private float currentYaw = 0.0f; // Current horizontal rotation angle
    private float currentPitch = 0.0f; // Current vertical rotation angle

    void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // Set the camera's position to the player's eye level
        transform.position = player.position + offset + player.up * 1.5f;

        // Rotate the camera based on mouse input
        currentYaw += Input.GetAxis("Mouse X") * sensitivity;
        currentPitch -= Input.GetAxis("Mouse Y") * sensitivity;
        currentPitch = Mathf.Clamp(currentPitch, minYAngle, maxYAngle);
        transform.rotation = Quaternion.Euler(currentPitch, currentYaw, 0.0f);
    }
}




