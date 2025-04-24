using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public virtual void Activate() {}
    public virtual void Awake() {}
    public virtual void Deactivate() {}
    public virtual void Update() {}
    public virtual void FixedUpdate() {}
}

public abstract class Ability<D> : Ability where D : AbilityData
{
    public D data;
    public PlayerControl owner;
    public Ability(D data, PlayerControl owner)
    {
        this.data=data;
        this.owner=owner;
    }
} 
