using UnityEngine;

public class KeyboadrInput : IInput
{
    public bool IsAttacking()
    {
        return IsLeftKeyPressed() && !IsRightKeyPressed();
    }

    public bool IsParrying()
    {
        return IsRightKeyPressed() && !IsLeftKeyPressed();
    }

    private bool IsLeftKeyPressed() => Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
    private bool IsRightKeyPressed() => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
}
