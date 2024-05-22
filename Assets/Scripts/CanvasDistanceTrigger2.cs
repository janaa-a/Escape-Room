using UnityEngine;

public class CanvasDistanceTrigger2 : MonoBehaviour
{
    public GameObject canvas;
    public float activationDistance = 3f;
    public Vector3 targetPosition = new Vector3(0, 0, 1);
    private bool canvasMoved = false;
    public GameObject player;

    void Start()
    {
        // Check if the canvas is set
        if (canvas == null)
        {
            UnityEngine.Debug.LogError("Canvas is not assigned in the inspector!");
            return;
        }

        // Initially show the canvas
        canvas.gameObject.SetActive(true);
    }

    void Update()
    {
        // Check if the player is within the activation distance
        if (Vector3.Distance(transform.position, player.transform.position) <= activationDistance)
        {
            // Move the canvas if it hasn't been moved yet
            if (!canvasMoved)
            {
                canvas.transform.position = targetPosition;
                canvasMoved = true;
            }
        }
        else
        {
            // Reset the canvas position if the player moves away (optional)
            if (canvasMoved)
            {
                // Move the canvas back to its original position or some other logic
                // Uncomment the line below if you want to reset the position
                // canvas.transform.position = originalPosition;
                canvasMoved = false;
            }
        }
    }
}
