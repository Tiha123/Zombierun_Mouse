using UnityEngine;

[CreateAssetMenu(menuName ="Abilities/Move")]
public class AbilityMoveData : AbilityData
{
    public float moveSpeed;
    public float rotateSpeed;
    public override Ability CreateAbility(PlayerControl owner)
    {
        return new AbilityMove(this, owner);
    }
}
