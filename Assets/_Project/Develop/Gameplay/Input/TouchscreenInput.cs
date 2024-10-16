using UnityEngine;

public class TouchscreenInput : PlayerInput
{
    private Camera _camera;

    public TouchscreenInput()
    {
        _camera = Camera.main;
    }

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

    private bool IsLeftKeyPressed() => Input.GetKey(KeyCode.Mouse0) && MousePosition < 0;
    private bool IsRightKeyPressed() => Input.GetKey(KeyCode.Mouse0) && MousePosition > 0;

    private float MousePosition => _camera.ScreenToWorldPoint(Input.mousePosition).x - _camera.transform.position.x;
}
