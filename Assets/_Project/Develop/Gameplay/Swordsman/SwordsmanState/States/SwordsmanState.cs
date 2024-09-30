public abstract class SwordsmanState
{
    protected readonly SwordsmanStateHandler StateHandler;
    protected readonly Swordsman Swordsman;

    private readonly SwordsmanStateName _name;

    public SwordsmanState(SwordsmanStateHandler stateHandler, SwordsmanStateName name, Swordsman swordsman)
    {
        StateHandler = stateHandler;
        _name = name;
        Swordsman = swordsman;
    }

    public SwordsmanStateName Name => _name;

    public abstract void Enter();
    public abstract void ChangeState(SwordsmanStateName stateName);
    public virtual void Exit() { }
}
