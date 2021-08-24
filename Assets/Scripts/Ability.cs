using UnityEngine;

public class Ability : ScriptableObject
{
    public string Name;
    public float CooldownTime;
    public float ActiveTime;

    public virtual void Activate(GameObject parent) { }
}
