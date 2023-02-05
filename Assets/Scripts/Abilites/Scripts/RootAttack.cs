using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RootAttack : Ability
{
    // Reference to the root attack prefab that will be instantiated
    public GameObject rootAttackPrefab;

    // Speed at which the root attack projectile will move
    public float projectileSpeed;

    // Overrides the UseAbility method from the parent class (Ability)
    public override void UseAbility(GameObject parent)
    {
        // Calls the base method (UseAbility) from the parent class (Ability)
        base.UseAbility(parent);

        // Gets the forward direction of the parent object (player)
        Vector3 forward = parent.transform.forward;

        // Calculates the position of the root attack projectile, 3 units away from the parent object in the forward direction and 0.5 units up
        Vector3 position = parent.transform.position + forward * 3 + new Vector3(0, 0.5f, 0);

        // Instantiates the root attack prefab at the calculated position and rotation of the parent object
        GameObject rootAttack = Instantiate(rootAttackPrefab, position, parent.transform.rotation);

        // Sets the forward direction of the root attack to be the same as the parent object's forward direction
        rootAttack.transform.forward = forward;

        // Adds a Rigidbody component to the root attack so it can move
        Rigidbody rigidbody = rootAttack.AddComponent<Rigidbody>();

        // Turns off gravity for the root attack so it will not be affected by gravity
        rigidbody.useGravity = false;

        // Adds force to the root attack in the forward direction, which will make it move at the specified speed
        rigidbody.AddForce(forward * projectileSpeed, ForceMode.Impulse);

        // Destroys the root attack after the specified active time from the scriptable object
        Destroy(rootAttack, activeTime);
        
    }

}
