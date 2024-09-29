using System.Collections;
using UnityEngine;

public class SwordsmanPreattackState : SwordsmanState
{
    private float _duration;
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

        Swordsman.Animation.SetPreattack();
        Swordsman.AttackIndicator.Activate(_duration);

        yield return new WaitForSeconds(_duration);

        StateHandler.SetAttackState();
    }

    public override void ChangeState(bool isAttacking, bool isParrying)
    {
        if (isParrying)
        {
            StateHandler.SetParryState();
        }
    }

    public override void Exit()
    {
        Coroutines.StopRoutine(_coroutine);
        Swordsman.AttackIndicator.Deactivate();
    }
}
