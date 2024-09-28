using UnityEngine;

public class KeyboadrInput : IInput
{
    private const string HORIZONTAL = "Horizontal";

    public bool IsAttacking()
    {
        return Input.GetAxis(HORIZONTAL) > 0;
    }

    public bool IsParrying()
    {
        return Input.GetAxis(HORIZONTAL) < 0;
    }
}
