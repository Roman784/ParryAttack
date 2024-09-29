public abstract class SwordsmanState
{
    protected readonly SwordsmanStateHandler StateHandler;
    protected readonly Swordsman Swordsman;

    public SwordsmanState(SwordsmanStateHandler stateHandler, Swordsman swordsman)
    {
        StateHandler = stateHandler;
        Swordsman = swordsman;
    }

    public abstract void Enter();
    public abstract void ChangeState(bool isAttacking, bool isParrying);
    public virtual void Exit() { }
}
