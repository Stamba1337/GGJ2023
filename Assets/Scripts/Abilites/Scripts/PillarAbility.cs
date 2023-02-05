using UnityEngine;

public class PillarAbility : Ability
{
    public GameObject prefab; // reference to the prefab

    public override void UseAbility(GameObject parent)
    {
        // spawn the prefab at the position and rotation of the parent
        GameObject spawnedPrefab = Instantiate(prefab, parent.transform.position + (parent.transform.forward * 2) + new Vector3(0, -0.4f, 0), Quaternion.Euler(new Vector3(-90, 0, 90)));
        Destroy(spawnedPrefab, 7.5f);
    }
}
