using UnityEngine;

public class SwordsmanParryState : SwordsmanState
{
    public SwordsmanParryState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, swordsman)
    {
    }

    public override void Enter()
    {
        Swordsman.Animation.SetParry();
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
