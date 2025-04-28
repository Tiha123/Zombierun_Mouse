using UnityEngine;
public enum FireState
{
    Loaded,
    Empty,
    Reloading
}

[CreateAssetMenu(menuName = "Abilities/Fire")]
public class AbilityFireData : AbilityData
{
    public int ammoRemain;
    public Gun currentGun;
    public FireState fireState { get; private set; }
    public override Ability CreateAbility(PlayerControl owner)
    {
        return new AbilityFire(this, owner);
    }

    public void SetFireState(FireState s)
    {
        fireState=s;
    }
}
