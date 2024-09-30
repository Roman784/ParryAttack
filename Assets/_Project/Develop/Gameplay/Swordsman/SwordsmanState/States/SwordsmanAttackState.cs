using System.Collections;
using UnityEngine;

public class SwordsmanAttackState : SwordsmanState
{
    private float _duration;
    private bool _isFinished;

    public SwordsmanAttackState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, SwordsmanStateName.Attack, swordsman)
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
        Swordsman.Animation.SetAttack();

        yield return new WaitForSeconds(_duration);

        _isFinished = true;

        StateHandler.ChangeState(Swordsman.IsAttacking, Swordsman.IsParrying);
    }

    public override void ChangeState(SwordsmanStateName stateName)
    {
        if (!_isFinished) return;

        if (stateName == SwordsmanStateName.Attack)
        {
            StateHandler.SetPreattackState();
        }
        else if (stateName == SwordsmanStateName.Parry)
        {
            StateHandler.SetParryState();
        }
        else
        {
            StateHandler.SetIdleState();
        }
    }
}
