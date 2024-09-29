using UnityEngine;

public class KeyboadrInput : IInput
{
    public bool IsAttacking()
    {
        return Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
    }

    public bool IsParrying()
    {
        return Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
    }
}
