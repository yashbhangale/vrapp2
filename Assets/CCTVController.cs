using UnityEngine;

public class CCTVController : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of camera rotation
    public Camera cctvCamera;         // Reference to the CCTV camera

    private bool isActive = false;    // Flag to check if the camera is active

    void Update()
    {
        if (isActive)
        {
            HandleRotation();
        }
    }

    // Handle camera rotation with WASD keys
    void HandleRotation()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D keys
        float vertical = Input.GetAxis("Vertical");     // W/S keys

        // Rotate around the Y-axis (left-right)
        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);

        // Tilt up and down (limit to prevent flipping)
        float newAngle = transform.eulerAngles.x - vertical * rotationSpeed * Time.deltaTime;
        if (newAngle < 80 || newAngle > 280) // Restrict tilt to -80° to +80°
        {
            transform.Rotate(Vector3.right, -vertical * rotationSpeed * Time.deltaTime);
        }
    }

    // Enable or disable the CCTV camera
    public void SetActive(bool active)
    {
        isActive = active;
        cctvCamera.enabled = active;
    }
}
