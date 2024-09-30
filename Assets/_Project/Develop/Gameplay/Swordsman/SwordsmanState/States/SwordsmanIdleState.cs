public class SwordsmanIdleState : SwordsmanState
{
    public SwordsmanIdleState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, SwordsmanStateName.Idle, swordsman)
    {
    }

    public override void Enter()
    {
        Swordsman.Animation.SetIdle();

        IsFinished = true;
    }
}
