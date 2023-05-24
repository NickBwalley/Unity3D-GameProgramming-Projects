using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // The player object to follow
    public Vector3 offset;    // The offset between the player and camera

    public float sensitivity = 2f; // The mouse sensitivity for rotating the camera

    public float minZoom = 5f;      // The minimum zoom level
    public float maxZoom = 15f;     // The maximum zoom level

    public float minVerticalAngle = 15;
    public float maxVerticalAngle = 45;

    public Vector2 framingOffset;

    public bool invertX;
    public bool invertY;

    public float damping = 5f;  // The damping factor for smoothing camera movements

    private float currentZoom = 10f; // The current zoom level
    private float pitch = 0f;   // The current pitch angle
    private float yaw = 0f;     // The current yaw angle

    private float invertXVal;
    private float invertYVal;

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        target = GameObject.Find("Lebron James").transform; // Replace "Player" with the name of your player object.
    }

    void LateUpdate()
    {
        // Move the camera to the player's position with the offset
        transform.position = Vector3.Lerp(transform.position, target.position + offset, damping * Time.deltaTime);

        // Zoom in/out with the mouse wheel
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;

        // Rotate the camera with the mouse
        yaw += Input.GetAxis("Mouse X") * sensitivity * invertXVal;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity * invertYVal;
        pitch = Mathf.Clamp(pitch, minVerticalAngle, maxVerticalAngle);

        // Apply the rotation to the camera
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        // Check if the player is visible
        RaycastHit hit;
        if (Physics.Raycast(target.position, transform.position - target.position, out hit, currentZoom))
        {
            // If the camera is obstructed, move it closer to the player
            transform.position = hit.point + (transform.position - hit.point).normalized * 0.2f;
        }

        //Horizontal rotation and camera facing you while infront   
        var targetPosition = Quaternion.Euler(pitch, yaw, 0);

        var focusPosition = target.position + new Vector3(framingOffset.x, framingOffset.y);

        transform.position = focusPosition - targetPosition * new Vector3(0, 0, currentZoom);
        transform.rotation = targetPosition;
    }
}
