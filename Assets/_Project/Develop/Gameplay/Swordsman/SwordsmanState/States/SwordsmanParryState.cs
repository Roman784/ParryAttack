using UnityEngine;

public class SwordsmanParryState : SwordsmanState
{
    public SwordsmanParryState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, swordsman)
    {
    }

    public override void Enter()
    {
        Debug.Log("Parry");

        Swordsman.Animation.SetParry();
    }

    public override void Update(IInput input)
    {
        if (input.IsAttacking())
        {
            StateHandler.SetPreattackState();
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
