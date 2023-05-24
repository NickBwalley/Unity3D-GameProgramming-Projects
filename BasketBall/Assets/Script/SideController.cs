using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideController : MonoBehaviour
{
    public Transform player;    // Reference to the player transform
    public float distance = 5f; // Distance between camera and player
    public float height = 2f;   // Height of camera above player
    public float smoothSpeed = 10f; // Speed of camera movement

    private float yaw = 0f; // Current yaw rotation of camera
    private float pitch = 0f; // Current pitch rotation of camera

    public float sensitivity = 2f; // Mouse sensitivity for camera rotation

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void LateUpdate()
    {
        // Get mouse input for camera rotation
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -20f, 80f); // Limit pitch rotation to prevent camera from flipping

        // Calculate camera position based on player position, camera distance, and height
        Vector3 targetPosition = player.position - transform.forward * distance + Vector3.up * height;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Set camera rotation to yaw and pitch values
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
