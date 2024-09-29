using UnityEngine;

public class KeyboadrInput : PlayerInput
{
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnParryTrigger.Invoke(true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            OnAttackTrigger.Invoke(true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            OnParryTrigger.Invoke(false);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            OnAttackTrigger.Invoke(false);
        }
    }
}
