using UnityEngine;

public abstract class AbilityData : ScriptableObject
{
    public abstract Ability CreateAbility(PlayerControl owner);
}
