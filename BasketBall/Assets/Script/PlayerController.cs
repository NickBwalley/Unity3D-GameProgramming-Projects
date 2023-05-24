using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;   // The speed at which the player moves
    public float jumpForce = 10f;   // The force applied to the player when jumping
    public float gravity = -20f;    // The force of gravity applied to the player

    private Vector3 moveDirection;  // The direction in which the player is moving
    private CameraController controller; // The character controller component

    void Start()
    {
        // Get the character controller component
        CharacterController characterController = GetComponent<CharacterController>();

        void Update()
        {
            // Get the player's movement input
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            // Calculate the movement direction based on the input and the player's forward direction
            moveDirection = transform.forward * z + transform.right * x;
            moveDirection.Normalize();

            // Apply the movement speed and gravity to the player
            moveDirection *= moveSpeed;
            moveDirection.y = gravity;

            // Jump if the player presses the space bar and is on the ground
            if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            {
                moveDirection.y = jumpForce;
            }

            // Apply the movement to the character controller
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}

