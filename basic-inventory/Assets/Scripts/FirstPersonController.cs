using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 2.0f;                  // The speed at which the character will move.
    public float mouseSensitivity = 2.0f;           // The mouse sensitivity.

    private float moveForward;                      // Stores the input value along the forward axis (W and S).
    private float moveRight;                        // Stores the input value along the right axis (D and A).

    private float rotationX;                        // Stores the input mouse's X axis value for player rotation.
    private float rotationY;                        // Stores the input mouse's Y axis value for player rotation.

    private CharacterController controller;         // The character controller attached to this player.
    private Camera playerCamera;                    // The camera acting as the player's eyes.

    // Use this for initialization.
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Get the input axis values from the player.
        moveForward = Input.GetAxis("Vertical") * moveSpeed;
        moveRight = Input.GetAxis("Horizontal") * moveSpeed;
        rotationX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Movement.
        Vector3 movement = new Vector3(moveRight, 0, moveForward);
        movement = transform.rotation * movement;
        controller.Move(movement * Time.deltaTime);

        // Rotation.
        transform.Rotate(0, rotationX, 0);
        playerCamera.transform.Rotate(-rotationY, 0, 0);
    }
}