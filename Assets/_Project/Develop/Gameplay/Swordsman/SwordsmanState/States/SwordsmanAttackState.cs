using System.Collections;
using UnityEngine;

public class SwordsmanAttackState : SwordsmanState
{
    private float _duration;
    private bool _isFinished;

    public SwordsmanAttackState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, swordsman)
    {
    }

    public override void Enter()
    {
        _isFinished = false;
        _duration = Swordsman.Config.AttributesConfig.AttackDuration;

        Coroutines.StartRoutine(Attack());
    }

    private IEnumerator Attack()
    {
        Debug.Log("Attack");

        Swordsman.Animation.SetAttack();

        yield return new WaitForSeconds(_duration);

        _isFinished = true;
        ChangeState(Swordsman.IsAttacking, Swordsman.IsParrying);
    }

    public override void ChangeState(bool isAttacking, bool isParrying)
    {
        if (!_isFinished) return;

        if (isAttacking)
        {
            StateHandler.SetPreattackState();
        }
        else if (isParrying)
        {
            StateHandler.SetParryState();
        }
        else
        {
            StateHandler.SetIdleState();
        }
    }
}
