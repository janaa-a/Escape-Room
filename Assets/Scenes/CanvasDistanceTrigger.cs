using System.Diagnostics;
using UnityEngine;

public class CanvasDistanceTrigger : MonoBehaviour
{
    public GameObject canvas;
    public float activationDistance = 3f;

    private bool canvasActive = false;
    public GameObject player;

    void Start()
    {
        // Check if the canvas is set
        if (canvas == null)
        {
            UnityEngine.Debug.LogError("Canvas is not assigned in the inspector!");
            return;
        }

        // Initially hide the canvas
        canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if the Main Camera is within the activation distance
        if (Vector3.Distance(transform.position, player.transform.position) <= activationDistance)
        {

            UnityEngine.Debug.Log("Dis: " + Vector3.Distance(transform.position, player.transform.position));
            // Activate the canvas if it's not already active
            if (!canvasActive)
            {
                canvas.gameObject.SetActive(true);
                canvasActive = true;
            }
        }
        else
        {
            // Deactivate the canvas if it's active
            if (canvasActive)
            {
                canvas.gameObject.SetActive(false);
                canvasActive = false;
            }
        }
    }
}