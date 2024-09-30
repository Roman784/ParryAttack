public class SwordsmanParryState : SwordsmanState
{
    public SwordsmanParryState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, SwordsmanStateName.Parry, swordsman)
    {
    }

    public override void Enter()
    {
        Swordsman.Animation.SetParry();

        IsFinished = true;
    }
}
