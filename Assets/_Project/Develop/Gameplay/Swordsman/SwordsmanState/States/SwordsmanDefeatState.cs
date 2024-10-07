public class SwordsmanDefeatState : SwordsmanState
{
    public SwordsmanDefeatState(SwordsmanStateHandler stateHandler, Swordsman swordsman) : base(stateHandler, SwordsmanStateName.Defeat, swordsman)
    {
    }

    public override void Enter()
    {
        Swordsman.ForbidFight();
        Swordsman.Animation.SetDefeat();
    }
}
