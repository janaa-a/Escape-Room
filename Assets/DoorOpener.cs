using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject door;
    public float openSpeed = 2f; // Speed at which the door opens
    public Vector3 openPosition; // The target position when the door is open
    private Vector3 closedPosition; // The original position of the door
    private bool isOpening = false; // Flag to check if the door is opening

    void Start()
    {
        if (door == null)
        {
            Debug.LogError("Door is not assigned in the inspector!");
            return;
        }

        // Save the initial closed position of the door
        closedPosition = door.transform.position;
    }

    void Update()
    {
        if (isOpening)
        {
            // Move the door towards the open position
            door.transform.position = Vector3.Lerp(door.transform.position, openPosition, Time.deltaTime * openSpeed);

            // Check if the door has reached the open position
            if (Vector3.Distance(door.transform.position, openPosition) < 0.01f)
            {
                door.transform.position = openPosition; // Snap to the exact position
                isOpening = false; // Stop opening
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger collider
        if (other.CompareTag("Player"))
        {
            isOpening = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player exited the trigger collider
        if (other.CompareTag("Player"))
        {
            isOpening = false;
            // Close the door
            door.transform.position = closedPosition;
        }
    }
}
