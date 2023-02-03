// Runs script in the editor
using UnityEngine;

[ExecuteInEditMode]
public class GroundCheck : MonoBehaviour
{
    // Distance threshold for checking if grounded
    public float distanceThreshold = .15f;
    // If the object is on the ground
    public bool isGrounded = true;

    // Event that triggers when grounded
    public event System.Action Grounded;

    // Offset to adjust raycast origin
    const float OriginOffset = .001f;
    // Calculates raycast origin position
    Vector3 RaycastOrigin => transform.position + Vector3.up * OriginOffset;
    // Calculates raycast distance
    float RaycastDistance => distanceThreshold + OriginOffset;

    // Runs every frame
    void LateUpdate()
    {
        // Checks if object is currently grounded
        bool isGroundedNow = Physics.Raycast(RaycastOrigin, Vector3.down, distanceThreshold * 2);
        // If object was not grounded and now is, triggers Grounded event
        if (isGroundedNow && !isGrounded)
        {
            Grounded?.Invoke();
        }
        // Updates isGrounded value
        isGrounded = isGroundedNow;
    }

    // Draws gizmo lines in the Editor
    void OnDrawGizmosSelected()
    {
        // Draws a white/red line representing the raycast
        Debug.DrawLine(RaycastOrigin, RaycastOrigin + Vector3.down * RaycastDistance, isGrounded ? Color.white : Color.red);
    }
}
