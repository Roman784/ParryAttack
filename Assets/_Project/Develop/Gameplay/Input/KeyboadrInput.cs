using UnityEngine;

public class KeyboadrInput : PlayerInput
{
    public override void Handle()
    {
        HandleIsAttacking();
        HandleIsParrying();
    }

    public void HandleIsAttacking()
    {
        bool result = IsRightKeyPressed() && !IsLeftKeyPressed();

        if (result == IsAttacking) return;

        IsAttacking = result;
        OnAttackTrigger.Invoke(result);
    }

    public void HandleIsParrying()
    {
        bool result = IsLeftKeyPressed() && !IsRightKeyPressed();

        if (result == IsParrying) return;

        IsParrying = result;
        OnParryTrigger.Invoke(result);
    }

    private bool IsLeftKeyPressed() => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
    private bool IsRightKeyPressed() => Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
}
