using System.Collections;
using UnityEngine;

public class SwordsmanPreattackState : SwordsmanState
{
    private float _duration;
    private bool _isFinished;
    private Coroutine _coroutine;

    public SwordsmanPreattackState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, SwordsmanStateName.Preattack, swordsman)
    {
    }

    public override void Enter()
    {
        _isFinished = false;
        _duration = Swordsman.Config.AttributesConfig.PreattackDuration;

        _coroutine = Coroutines.StartRoutine(Preattack());
    }

    private IEnumerator Preattack()
    {
        Swordsman.Animation.SetPreattack();
        Swordsman.AttackIndicator.Activate(_duration);

        yield return new WaitForSeconds(_duration);

        _isFinished = true;

        ChangeState(SwordsmanStateName.Attack);
    }

    public override void ChangeState(SwordsmanStateName stateName)
    {
        if (stateName == SwordsmanStateName.Parry)
        {
            StateHandler.SetParryState();
        }
        else if (_isFinished)
        {
            StateHandler.SetAttackState();
        }
    }

    public override void Exit()
    {
        if (_coroutine != null)
            Coroutines.StopRoutine(_coroutine);

        Swordsman.AttackIndicator.Deactivate();
    }
}
