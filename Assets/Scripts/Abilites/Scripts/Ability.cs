using UnityEngine;

public class Ability : ScriptableObject
{
    public string abilityName;
    public float cooldownTime;
    public float activeTime;

    public virtual void UseAbility(GameObject parent)
    {
        Debug.Log("used " + abilityName);
    }
}