using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityReload : Ability<AbilityReloadData>
{
    public AbilityReload(AbilityReloadData data, PlayerControl owner) : base(data, owner)
    {
    }

    void InputReload(InputAction.CallbackContext ctx)
    {
        owner.animator.SetTrigger("Reload");
    }

    public override void Activate()
    {
        owner.input.playerActions.Reload.performed+=InputReload;
    }

    public override void Deactivate()
    {
        owner.input.playerActions.Reload.performed-=InputReload;
    }
}
