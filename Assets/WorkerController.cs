using UnityEngine;

public class WorkerController : MonoBehaviour
{
    private CharacterController characterController;

    private bool isFPSMode = false;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float moveSpeed = 5f;     // Player movement speed
    public float jumpHeight = 1.5f;  // Jump height
    public float gravity = -9.81f;   // Gravity value

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isFPSMode)
        {
            HandleFPSControls();
        }
    }

    public void EnableFPSMode(bool enable)
    {
        isFPSMode = enable;

        if (enable)
        {
            // Optionally, reset player velocity when entering FPS mode
            playerVelocity = Vector3.zero;
        }
    }

    void HandleFPSControls()
    {
        // Check if the player is grounded
        isGrounded = characterController.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Move the player
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Jumping logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        playerVelocity.y += gravity * Time.deltaTime;

        // Move the player vertically (for jumping and gravity)
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
