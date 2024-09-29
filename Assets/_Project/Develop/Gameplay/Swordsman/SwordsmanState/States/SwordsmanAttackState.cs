using System.Collections;
using UnityEngine;

public class SwordsmanAttackState : SwordsmanState
{
    private Coroutine _coroutine;

    private float _preattackDuration;
    private float _attackDuration;

    private bool _isAttack;
    private bool _isPreattack;

    public SwordsmanAttackState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, swordsman)
    {
    }

    public override void Enter()
    {
        _preattackDuration = Swordsman.Config.AttributesConfig.PreattackDuration;
        _attackDuration = Swordsman.Config.AttributesConfig.AttackDuration;

        _isAttack = false;
        _isPreattack = false;

        _coroutine = Coroutines.StartRoutine(Attack());
    }

    private IEnumerator Attack()
    {
        Debug.Log("Preattack");

        _isPreattack = true;
        Swordsman.Animation.SetPreattack();
        Swordsman.AttackIndicator.Activate(_preattackDuration);

        yield return new WaitForSeconds(_preattackDuration);

        Debug.Log("Attack");

        _isAttack = true;
        _isPreattack = false;
        Swordsman.Animation.SetAttack();

        yield return new WaitForSeconds(_attackDuration);

        _isAttack = false;
    }

    public override void Update(IInput input)
    {
        if (input.IsParrying() && _isPreattack)
        {
            StateHandler.SetParryState();
        }
        else if (!_isPreattack && !_isAttack)
        {
            if (input.IsAttacking())
            {
                StateHandler.SetAttackState();
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
    }

    public override void Exit() 
    {
        Coroutines.StopRoutine(_coroutine);
        Swordsman.AttackIndicator.Deactivate();
    }
}
