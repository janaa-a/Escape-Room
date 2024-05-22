using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    public InputField passwordInputField; // Reference to the InputField
    public Button submitButton;           // Reference to the Button
    public GameObject keyObject;          // Reference to the key object
    private string correctPassword = "1234"; // The correct password

    void Start()
    {
        // Ensure the key object is hidden at the start
        keyObject.SetActive(false);

        // Add listener for the button click
        submitButton.onClick.AddListener(CheckPassword);
    }

    void CheckPassword()
    {
        // Check if the input password is correct
        if (passwordInputField.text == correctPassword)
        {
            // If the password is correct, show the key object
            keyObject.SetActive(true);
        }
        else
        {
            // If the password is incorrect, you can handle it here
            Debug.Log("Incorrect password");
        }
    }
}
