using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityMove : Ability<AbilityMoveData>
{
    Vector2 value;
    Vector3 camPos;
    Vector3 movement;
    Quaternion direction;
    Vector3 target;
    Vector3 position;
    public AbilityMove(AbilityMoveData data, PlayerControl owner) : base(data, owner)
    {

    }

    void InputMove(InputAction.CallbackContext ctx)
    {
        value = ctx.ReadValue<Vector2>();
        camPos = owner.cam.transform.forward.normalized+owner.cam.transform.right.normalized;
        camPos.y=0f;
        camPos.Normalize();
        movement = new Vector3(camPos.x * value.x, 0f, camPos.z * value.y) * data.moveSpeed * Time.deltaTime;

    }
    public override void Activate()
    {
        owner.input.playerActions.Move.performed += InputMove;
    }

    public override void Deactivate()
    {
        owner.input.playerActions.Move.performed -= InputMove;
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
            direction = Quaternion.LookRotation((target - position).normalized);
            owner.rb.rotation = Quaternion.Slerp(owner.transform.rotation, direction, Time.deltaTime * data.rotateSpeed);
        }
        if(value==Vector2.zero)
        {
            owner.rb.linearVelocity=Vector3.zero;
        }
        owner.rb.MovePosition(owner.rb.position+movement);
    }
}
