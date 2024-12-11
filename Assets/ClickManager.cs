using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public Text infoText; // Reference to the UI Text element
    private Camera mainCamera;

    private BoxInfo lastClickedBox; // To track the last clicked box

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        infoText.text = ""; // Clear any initial text
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Debug.Log("Mouse Click Detected"); // Check if the click is registered

            // Cast a ray from the mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"Raycast hit: {hit.collider.name}"); // Log what the raycast hit

                // Check if the clicked object has a BoxInfo component
                BoxInfo boxInfo = hit.collider.GetComponent<BoxInfo>();
                if (boxInfo != null)
                {
                    Debug.Log("BoxInfo component found! Displaying info."); // Log success
                    // Display the clicked box's information
                    infoText.text = $"Product ID: {boxInfo.productID}\n" +
                                    $"Manufacturing Date: {boxInfo.manufacturingDate}\n" +
                                    $"Expiry Date: {boxInfo.expiryDate}\n" +
                                    $"Location: {boxInfo.location}\n" +
                                    $"Temperature: {boxInfo.randomTemperature}°C";

                    lastClickedBox = boxInfo; // Save the clicked box info
                }
                else
                {
                    Debug.Log("No BoxInfo component found on the clicked object."); // Log failure
                    ClearInfo();
                }
            }
            else
            {
                Debug.Log("Raycast hit nothing."); // Log if nothing was hit
                ClearInfo();
            }
        }
    }

    void ClearInfo()
    {
        infoText.text = "";
        lastClickedBox = null;
    }
}
