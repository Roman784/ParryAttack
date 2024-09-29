using System.Collections;
using UnityEngine;

public class SwordsmanAttackState : SwordsmanState
{
    private Coroutine _coroutine;

    private bool _isAttack;
    private bool _isPreattack;

    public SwordsmanAttackState(SwordsmanStateHandler stateHandler) : base(stateHandler)
    {
    }

    public override void Enter()
    {
        _isAttack = false;
        _isPreattack = false;

        _coroutine = Coroutines.StartRoutine(Attack());
    }

    private IEnumerator Attack()
    {
        _isPreattack = true;

        yield return new WaitForSeconds(1f);

        _isAttack = true;
        _isPreattack = false;

        yield return new WaitForSeconds(1f);

        _isAttack = false;
    }

    public override void Update(IInput input)
    {
        if (input.IsParrying() && _isPreattack)
        {
            StateHandler.SetParryState();
        }
        else if (!input.IsAttacking() && !input.IsParrying() && !_isPreattack && !_isAttack)
        {
            StateHandler.SetIdleState();
        }
    }

    public override void Exit() 
    {
        Coroutines.StopRoutine(_coroutine);
    }
}
