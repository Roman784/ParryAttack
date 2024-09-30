public class SwordsmanIdleState : SwordsmanState
{
    public SwordsmanIdleState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, SwordsmanStateName.Idle, swordsman)
    {
    }

    public override void Enter()
    {
        Swordsman.Animation.SetIdle();
    }

    public override void ChangeState(SwordsmanStateName stateName)
    {
        if (stateName == SwordsmanStateName.Attack)
        {
            StateHandler.SetPreattackState();
        }
        else if (stateName == SwordsmanStateName.Parry)
        {
            StateHandler.SetParryState();
        }
    }
}
