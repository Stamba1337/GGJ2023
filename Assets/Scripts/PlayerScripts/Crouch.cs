using UnityEngine;

// The `Crouch` class adds crouching functionality to a first-person character.
public class Crouch : MonoBehaviour
{
    // Key code to trigger crouching.
    public KeyCode keyForCrouch = KeyCode.LeftControl;

    // Variables for slowing down the character when crouched.
    [Header("Slow Movement")]
    public FirstPersonMovement movement;
    public float movementSpeed = 2;

    // Variables for lowering the character's head when crouched.
    [Header("Low Head")]
    public Transform headToLower;
    [HideInInspector]
    public float? defaultHeadYLocalPosition;
    public float crouchYHeadPosition = 1;

    // Variables for lowering the character's collider when crouched.
    public CapsuleCollider colliderToLower;
    [HideInInspector]
    public float? defaultColliderHeight;

    // Flag to check if the character is currently crouched.
    public bool IsCrouched { get; private set; }

    // Events for starting and ending crouching.
    public event System.Action CrouchStart, CrouchEnd;

    // Function to reset the variables to default values if they haven't been set.
    void Reset()
    {
        // Get the `FirstPersonMovement` component.
        movement = GetComponentInParent<FirstPersonMovement>();

        // Get the character's camera and collider.
        headToLower = movement.GetComponentInChildren<Camera>().transform;
        colliderToLower = movement.GetComponentInChildren<CapsuleCollider>();
    }

    // Function that updates the character's position and movement every frame.
    void LateUpdate()
    {
        // Check if the left control key is pressed.
        if (Input.GetKey(keyForCrouch))
        {
            // Lower the character's head.
            if (headToLower)
            {
                if (!defaultHeadYLocalPosition.HasValue)
                {
                    defaultHeadYLocalPosition = headToLower.localPosition.y;
                }
                headToLower.localPosition = new Vector3(headToLower.localPosition.x, crouchYHeadPosition, headToLower.localPosition.z);
            }

            // Lower the character's collider.
            if (colliderToLower)
            {
                if (!defaultColliderHeight.HasValue)
                {
                    defaultColliderHeight = colliderToLower.height;
                }
                float loweringAmount;
                if (defaultHeadYLocalPosition.HasValue)
                {
                    loweringAmount = defaultHeadYLocalPosition.Value - crouchYHeadPosition;
                }
                else
                {
                    loweringAmount = defaultColliderHeight.Value * .5f;
                }
                colliderToLower.height = Mathf.Max(defaultColliderHeight.Value - loweringAmount, 0);
                colliderToLower.center = Vector3.up * colliderToLower.height * .5f;
            }
            if (!IsCrouched)
            {
                IsCrouched = true;
                SetSpeedOverrideActive(true);
                CrouchStart?.Invoke();
            }
        }
        else
        {
            if (IsCrouched)
            {
                if (headToLower)
                {
                    headToLower.localPosition = new Vector3(headToLower.localPosition.x, defaultHeadYLocalPosition.Value, headToLower.localPosition.z);
                }
                if (colliderToLower)
                {
                    colliderToLower.height = defaultColliderHeight.Value;
                    colliderToLower.center = Vector3.up * colliderToLower.height * .5f;
                }
                IsCrouched = false;
                SetSpeedOverrideActive(false);
                CrouchEnd?.Invoke();
            }
        }
    }
    // Adds or removes the crouch speed override depending on the state
    void SetSpeedOverrideActive(bool state)
    {
        if (!movement)
        {
            // If the movement component is not found, return early
            return;
        }

        if (state)
        {
            if (!movement.speedOverrides.Contains(SpeedOverride))
            {
                // If the speed override is not already in the list, add it
                movement.speedOverrides.Add(SpeedOverride);
            }
        }
        else
        {
            if (movement.speedOverrides.Contains(SpeedOverride))
            {
                // If the speed override is in the list, remove it
                movement.speedOverrides.Remove(SpeedOverride);
            }
        }
    }

    // The method that returns the movement speed when crouched
    float SpeedOverride() => movementSpeed;
}