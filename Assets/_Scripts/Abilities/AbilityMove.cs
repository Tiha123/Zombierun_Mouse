using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityMove : Ability<AbilityMoveData>
{
    Vector2 value;
    Vector3 movement;
    Vector3 direction;
    Vector3 target;
    Vector3 position;
    public AbilityMove(AbilityMoveData data, PlayerControl owner) : base(data, owner)
    {

    }

    void InputMove(InputAction.CallbackContext ctx)
    {
        value = ctx.ReadValue<Vector2>();
    }
    void InputStop(InputAction.CallbackContext ctx)
    {
    
    }
    public override void Activate()
    {
        owner.input.playerActions.Move.performed += InputMove;
        owner.input.playerActions.Move.canceled += InputStop;
    }

    public override void Deactivate()
    {
        owner.input.playerActions.Move.performed -= InputMove;
        owner.input.playerActions.Move.canceled -= InputStop;
    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
        Ray ray = owner.cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out var hit) == true)
        {
            position = owner.transform.position;
            target = hit.point;
            target.y = position.y;
            direction = (target - position).normalized;
            
            owner.rb.rotation = Quaternion.Slerp(owner.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * data.rotateSpeed);
        }
        
    }
}
