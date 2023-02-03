using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField] // Shows the field in the Inspector, allowing it to be assigned in the Editor
    Transform character; // Transform component of the character that will be rotated
    public float sensitivity = 2; // Sensitivity of mouse movement for rotation
    public float smooth = 1.5f; // Smoothness of rotation
    Vector2 velocity; // Total velocity of mouse movement
    Vector2 frameVelocity; // Velocity of mouse movement in a single frame

    void Reset()
    {
        // Assigns the parent's FirstPersonMovement component's transform to character
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }
    void Start()
    {
        // Locks the cursor in the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Calculates mouse movement delta
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // Calculates raw frame velocity
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);

        // Smoothens the raw frame velocity
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smooth);

        // Adds the frame velocity to total velocity
        velocity += frameVelocity;

        // Clamps the y-axis rotation to between -90 and 90 degrees
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        // Rotates the transform's y-axis rotation based on total velocity
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }
}
