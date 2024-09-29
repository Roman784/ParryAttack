using UnityEngine;

public class SwordsmanIdleState : SwordsmanState
{
    public SwordsmanIdleState(SwordsmanStateHandler stateHandler) : base(stateHandler)
    {
    }

    public override void Enter()
    {
    }

    public override void Update(IInput input)
    {
        if (input.IsAttacking())
        {
            StateHandler.SetAttackState();
        }
        else if (input.IsParrying())
        {
            StateHandler.SetParryState();
        }
    }

    public override void Exit()
    {
    }
}
