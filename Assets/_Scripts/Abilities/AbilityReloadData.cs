using UnityEngine;

[CreateAssetMenu(menuName ="Abilities/Reload")]
public class AbilityReloadData : AbilityData
{
    public override Ability CreateAbility(PlayerControl owner)
    {
        return new AbilityReload(this, owner);
    }
}
