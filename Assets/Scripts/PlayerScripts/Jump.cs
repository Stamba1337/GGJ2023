using UnityEngine;

public class Jump : MonoBehaviour
{
    new Rigidbody rigidbody; // Reference to Rigidbody component
    public float jumpStrength = 2; // Strength of the jump
    public event System.Action Jumped; // Event for when the object jumps
    [SerializeField] GroundCheck groundCheck; // Reference to GroundCheck script


    // Called when the script is reset in the editor
    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>(); // Finds the GroundCheck script
    }

    // Called when the script is enabled
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>(); // Finds the Rigidbody component
    }

    // Called after all other updates have been processed
    void LateUpdate()
    {
        // Check if the jump button is pressed and the object is on the ground
        if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength); // Apply upward force to the Rigidbody
            Jumped?.Invoke(); // Invoke the Jumped event
        }
    }
}