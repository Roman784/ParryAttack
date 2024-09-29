using UnityEngine.Events;

public abstract class PlayerInput
{
    public UnityEvent<bool> OnAttackTrigger = new();
    public UnityEvent<bool> OnParryTrigger = new();

    public virtual void Update() { }

    public virtual bool IsAttacking() { return false; }
    public virtual bool IsParrying() { return false; }
}
