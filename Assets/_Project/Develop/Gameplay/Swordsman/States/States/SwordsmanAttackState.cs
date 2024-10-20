using System.Collections;
using UnityEngine;

public class SwordsmanAttackState : SwordsmanState
{
    private float _duration;

    public SwordsmanAttackState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, SwordsmanStateName.Attack, swordsman)
    {
    }

    public override void Enter()
    {
        IsFinished = false;

        _duration = Swordsman.Config.FeaturesConfig.AttackDuration;

        Coroutines.StartRoutine(Attack());
    }

    private IEnumerator Attack()
    {
        Swordsman.PerformAttack();
        Swordsman.Animation.SetAttack();
        Swordsman.Sound.PlayAttackSound();

        yield return new WaitForSeconds(_duration);

        IsFinished = true;

        StateHandler.ChangeState(Swordsman.IsAttacking, Swordsman.IsParrying);
    }
}
