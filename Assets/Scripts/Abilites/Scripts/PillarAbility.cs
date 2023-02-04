using UnityEngine;
using UnityEngine.LowLevel;

[CreateAssetMenu]
public class PillarAbility : Ability
{
    public GameObject pillarPrefab; // reference to the pillar prefab

    public override void UseAbility(GameObject parent)
    {
        base.UseAbility(parent);

        // Get the FirstPersonLook component of the parent
        FirstPersonLook look = parent.GetComponentInChildren<FirstPersonLook>();

        // Cast a ray at where the player is looking
        RaycastHit hit;
        if (Physics.Raycast(parent.transform.position, look.transform.forward, out hit))
        {
            // Spawn the pillar where the player is looking
            GameObject pillar = Instantiate(pillarPrefab, hit.point, Quaternion.identity);

            // Add a collider component to the pillar
            Collider pillarCollider = pillar.AddComponent<BoxCollider>();
            pillarCollider.isTrigger = false;

            // Add an empty child with another collider component set as trigger
            GameObject child = new GameObject();
            child.transform.parent = pillar.transform;
            Collider childCollider = child.AddComponent<BoxCollider>();
            childCollider.isTrigger = true;

            // Make the trigger collider call the PillarRise function when the player enters
            childCollider.gameObject.AddComponent<PillarRise>();
        }
    }
}

public class PillarRise : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Move the pillar upwards when the player enters the trigger collider
        if (other.CompareTag("Player"))
        {
            // Detach the child from the parent to prevent glitching
            transform.parent = null;
            // Move the parent (pillar) upwards
            transform.position += Vector3.up;
        }
    }
}
