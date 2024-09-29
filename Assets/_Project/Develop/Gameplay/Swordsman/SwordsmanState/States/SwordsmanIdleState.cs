using UnityEngine;

public class SwordsmanIdleState : SwordsmanState
{
    public SwordsmanIdleState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, swordsman)
    {
    }

    public override void Enter()
    {
        Swordsman.Animation.SetIdle();
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
