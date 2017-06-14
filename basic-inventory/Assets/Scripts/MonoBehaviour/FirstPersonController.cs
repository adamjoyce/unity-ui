using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 2.0f;                  // The speed at which the character will move.
    public float mouseSensitivity = 2.0f;           // The mouse sensitivity.
    public  Inventory playerInventory;              // This player's inventory.

    private float moveForward;                      // Stores the input value along the forward axis (W and S).
    private float moveRight;                        // Stores the input value along the right axis (D and A).

    private float rotationX;                        // Stores the input mouse's X axis value for player rotation.
    private float rotationY;                        // Stores the input mouse's Y axis value for player rotation.

    private CharacterController controller;         // The character controller attached to this player.
    private Camera playerCamera;                    // The camera acting as the player's eyes.

    /* Use this for initialization. */
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    /* Update is called once per frame. */
    private void Update()
    {
        Movement();
        CameraRotation();

        // Picking up items.
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100))
            {
                GameObject objectHit = hit.transform.gameObject;
                SceneItem sceneItem = objectHit.GetComponent<SceneItem>();
                if (sceneItem)
                {
                    sceneItem.PickupItem(playerInventory);
                }
            }
        }

        // Inventory item selection.
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            // Wheel scrolls up.
            playerInventory.ChangeSelectedItem(false);
            Debug.Log(playerInventory.selectedItemIndex);
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            // Wheel scrolls down.
            playerInventory.ChangeSelectedItem(true);
            Debug.Log(playerInventory.selectedItemIndex);
        }

        // Dropping items.
        if (Input.GetButtonDown("Fire2"))
        {
            if (playerInventory.items[playerInventory.selectedItemIndex])
            {
                playerInventory.items[playerInventory.selectedItemIndex].sceneObject.GetComponent<SceneItem>().DropItem(playerInventory, transform);
            }
        }
    }

    /* Moves the player based on axis inputs. */
    private void Movement()
    {
        // Get the input axis values from the player.
        moveForward = Input.GetAxis("Vertical") * moveSpeed;
        moveRight = Input.GetAxis("Horizontal") * moveSpeed;

        // Apply Movement.
        Vector3 movement = new Vector3(moveRight, 0, moveForward);
        movement = transform.rotation * movement;
        controller.Move(movement * Time.deltaTime);
    }

    /* Rotates the player based on mouse axis inputs. */
    private void CameraRotation()
    {
        // Get the input axis from the player.
        rotationX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Apply Rotation.
        transform.Rotate(0, rotationX, 0);
        playerCamera.transform.Rotate(-rotationY, 0, 0);
    }

    /* Attempts to pickup */
    private void PickupInteractable()
    {

    }
}