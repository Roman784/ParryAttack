using System.Collections;
using UnityEngine;

public class SwordsmanPreattackState : SwordsmanState
{
    private float _duration;
    private bool _isFinished;
    private Coroutine _coroutine;

    public SwordsmanPreattackState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, swordsman)
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
        Debug.Log("Preattack");

        Swordsman.Animation.SetPreattack();
        Swordsman.AttackIndicator.Activate(_duration);

        yield return new WaitForSeconds(_duration);

        _isFinished = true;
        ChangeState(false, false);
    }

    public override void ChangeState(bool isAttacking, bool isParrying)
    {
        if (isParrying)
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
