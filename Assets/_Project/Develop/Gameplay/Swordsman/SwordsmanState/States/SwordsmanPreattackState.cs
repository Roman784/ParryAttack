using System.Collections;
using UnityEngine;

public class SwordsmanPreattackState : SwordsmanState
{
    private float _duration;
    private Coroutine _coroutine;

    public SwordsmanPreattackState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, SwordsmanStateName.Preattack, swordsman)
    {
    }

    public override void Enter()
    {
        IsFinished = true; // You can change from this state to another state at runtime, so it is always finished.

        _duration = Swordsman.Config.FeaturesConfig.PreattackDuration;

        _coroutine = Coroutines.StartRoutine(Preattack());
    }

    private IEnumerator Preattack()
    {
        Swordsman.Animation.SetPreattack();
        Swordsman.AttackIndicator.Activate(_duration);

        yield return new WaitForSeconds(_duration);

        StateHandler.ChangeState(SwordsmanStateName.Attack);
    }

    public override void Exit()
    {
        if (_coroutine != null)
            Coroutines.StopRoutine(_coroutine);

        Swordsman.AttackIndicator.Deactivate();
    }
}
