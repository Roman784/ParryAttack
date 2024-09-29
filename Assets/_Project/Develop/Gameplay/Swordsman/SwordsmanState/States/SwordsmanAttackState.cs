using System.Collections;
using UnityEngine;

public class SwordsmanAttackState : SwordsmanState
{
    private float _duration;

    public SwordsmanAttackState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, swordsman)
    {
    }

    public override void Enter()
    {
        _duration = Swordsman.Config.AttributesConfig.AttackDuration;

        Coroutines.StartRoutine(Attack());
    }

    private IEnumerator Attack()
    {
        Debug.Log("Attack");

        Swordsman.Animation.SetAttack();

        yield return new WaitForSeconds(_duration);

        StateHandler.SetIdleState();
    }

    public override void ChangeState(bool isAttacking, bool isParrying)
    {
    }
}
