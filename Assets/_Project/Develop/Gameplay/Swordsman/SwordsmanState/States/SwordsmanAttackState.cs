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
        _duration = Swordsman.Config.AttributesConfig.AttackDuration;

        Coroutines.StartRoutine(Attack());
    }

    private IEnumerator Attack()
    {
        Debug.Log("Attack");

        _isFinished = false;

        Swordsman.Animation.SetAttack();

        yield return new WaitForSeconds(_duration);

        _isFinished = true;
    }

    public override void Update(IInput input)
    {
        if (!_isFinished) return;

        if (input.IsAttacking())
        {
            StateHandler.SetPreattackState();
        }
        else if (input.IsParrying())
        {
            StateHandler.SetParryState();
        }
        else
        {
            StateHandler.SetIdleState();
        }
    }

    public override void Exit() 
    {
    }
}
