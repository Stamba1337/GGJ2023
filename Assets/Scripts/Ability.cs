using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/New Ability")]
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