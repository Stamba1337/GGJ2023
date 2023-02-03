using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public Vector2 targetVelocity;

    // Character speed when not running
    public float speed = 5;

    // Character speed when running
    public float runSpeed = 9;

    // Flag to determine if character can run
    public bool canRun = true;

    // Property to determine if character is running
    public bool IsRunning { get; private set; }

    // Key to start running
    public KeyCode keyForRunning = KeyCode.LeftShift;

    // Reference to Rigidbody component
    new Rigidbody rigidbody;

    // Functions to override movement speed
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    // Initialize reference to Rigidbody component
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update character's velocity based on user input
    void FixedUpdate()
    {
        // Determine if character is running
        IsRunning = canRun && Input.GetKey(keyForRunning);

        // Calculate target speed
        float targetMovingSpeed = IsRunning ? runSpeed : speed;

        // Use last added speed override if any
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Calculate target velocity
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Set character's velocity
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }
}
