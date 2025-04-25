using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityFire : Ability<AbilityFireData>
{
    public AbilityFire(AbilityFireData data, PlayerControl owner) : base(data, owner)
    {
        data.currentGun=owner.currentGun;
        data.ammoRemain=owner.currentGun.magSize+1;
    }

    void InputFire(InputAction.CallbackContext ctx)
    {
        Ray ray=new Ray(data.currentGun.transform.position, data.currentGun.transform.forward);
        if(data.fireState==FireState.Loaded&&data.ammoRemain<=0)
        {
            Physics.Raycast(ray, out RaycastHit hit, data.currentGun.maxRange);
        }
    }

    public override void Activate()
    {
        owner.input.playerActions.Attack.performed+=InputFire;
    }

    public override void Deactivate()
    {
        owner.input.playerActions.Attack.performed-=InputFire;
    }
}
