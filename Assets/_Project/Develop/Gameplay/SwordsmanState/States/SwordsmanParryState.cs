using UnityEngine;

public class SwordsmanParryState : SwordsmanState
{
    public SwordsmanParryState(SwordsmanStateHandler stateHandler) : base(stateHandler)
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
        else if (!input.IsParrying())
        {
            StateHandler.SetIdleState();
        }
    }

    public override void Exit()
    {
    }
}
