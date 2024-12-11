using UnityEngine;

public class ChatButtonController : MonoBehaviour
{
    public GameObject cctvPanel; // Reference to the CCTV Panel

    // Method to toggle the CCTV Panel visibility
    public void ToggleCCTVPanel()
    {
        if (cctvPanel != null)
        {
            bool isActive = cctvPanel.activeSelf;
            cctvPanel.SetActive(!isActive); // Toggle the panel's active state
        }
    }
}
