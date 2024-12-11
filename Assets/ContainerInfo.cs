using UnityEngine;

public class ContainerInfo : MonoBehaviour
{
    public string containerID;           // Unique ID for the container
    public string productName;           // Product name
    public string manufacturingDate;     // Manufacturing date
    public string expiryDate;            // Expiry date
    public Vector2 gpsCoordinates;       // GPS coordinates (latitude, longitude)
    public float temperature;            // Fake temperature data

    private void Start()
    {
        // Generate random temperature for the container
        temperature = Random.Range(-20f, 40f); // Fake temperature range
    }
}
