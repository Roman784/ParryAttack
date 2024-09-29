using UnityEngine;

public class SwordsmanIdleState : SwordsmanState
{
    public SwordsmanIdleState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, swordsman)
    {
    }

    public override void Enter()
    {
        Debug.Log("Idle");

        Swordsman.Animation.SetIdle();
    }

    public override void ChangeState(bool isAttacking, bool isParrying)
    {
        if (isAttacking)
        {
            StateHandler.SetPreattackState();
        }
        else if (isParrying)
        {
            StateHandler.SetParryState();
        }
    }
}
