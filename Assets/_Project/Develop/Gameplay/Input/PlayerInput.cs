using UnityEngine.Events;

public abstract class PlayerInput
{
    public UnityEvent<bool> OnAttackTrigger = new();
    public UnityEvent<bool> OnParryTrigger = new();

    protected bool IsAttacking;
    protected bool IsParrying;

    public virtual void Handle() { }
}
