public class SwordsmanParryState : SwordsmanState
{
    public SwordsmanParryState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, SwordsmanStateName.Parry, swordsman)
    {
    }

    public override void Enter()
    {
        Swordsman.Animation.SetParry();
    }

    public override void ChangeState(SwordsmanStateName stateName)
    {
        if (stateName == SwordsmanStateName.Attack)
        {
            StateHandler.SetPreattackState();
        }
        else if (stateName != SwordsmanStateName.Parry)
        {
            StateHandler.SetIdleState();
        }
    }
}
