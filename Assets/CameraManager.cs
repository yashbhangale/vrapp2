using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;           // Overhead camera
    public Camera fpsCamera;            // FPS camera attached to the worker
    public Camera cctvCamera;           // Cold storage CCTV camera
    public Camera wasteDisposalCCTV;    // Waste disposal CCTV camera
    public Camera workareaCamera;
    public Camera receptionCamera;
    private Camera activeCamera;        // Tracks the currently active camera

    public WorkerController workerController; // Reference to the player controller script

    void Start()
    {
        // Activate the main camera at the start of the game
        ActivateCamera(mainCamera);
    }

    public void ActivateCamera(Camera cameraToActivate)
    {
        // Disable all cameras
        mainCamera.enabled = false;
        fpsCamera.enabled = false;
        cctvCamera.enabled = false;
        wasteDisposalCCTV.enabled = false;
	workareaCamera.enabled = false;
	receptionCamera.enabled = false;

        // Enable the chosen camera
        cameraToActivate.enabled = true;
        activeCamera = cameraToActivate;

        // Handle FPS-specific logic
        if (cameraToActivate == fpsCamera)
        {
            if (workerController != null)
            {
                workerController.EnableFPSMode(true);
            }
        }
        else
        {
            if (workerController != null)
            {
                workerController.EnableFPSMode(false);
            }
        }
    }
}
