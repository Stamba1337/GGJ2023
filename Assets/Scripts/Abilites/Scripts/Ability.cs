using UnityEngine;

public class Ability : ScriptableObject
{
    public string abilityName;
    public float cooldownTime;
    public float activeTime;
    public int damage;

    public virtual void UseAbility(GameObject parent)
    {
        Debug.Log("used " + abilityName);
    }
}