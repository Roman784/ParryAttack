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
        _duration = Swordsman.Config.AttributesConfig.PreattackDuration;

        _coroutine = Coroutines.StartRoutine(Preattack());
    }

    private IEnumerator Preattack()
    {
        Debug.Log("Preattack");

        _isFinished = false;

        Swordsman.Animation.SetPreattack();
        Swordsman.AttackIndicator.Activate(_duration);

        yield return new WaitForSeconds(_duration);

        _isFinished = true;
    }

    public override void Update(IInput input)
    {
        if (!_isFinished && input.IsParrying())
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
        Coroutines.StopRoutine(_coroutine);
        Swordsman.AttackIndicator.Deactivate();
    }
}
