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

    public override void ChangeState(bool isAttacking, bool isParrying)
    {
        if (isAttacking)
        {
            StateHandler.SetPreattackState();
        }
        else
        {
            StateHandler.SetIdleState();
        }
    }
}
