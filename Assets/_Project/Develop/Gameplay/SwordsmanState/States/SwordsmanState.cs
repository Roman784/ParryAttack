public abstract class SwordsmanState
{
    protected readonly SwordsmanStateHandler StateHandler;

    public SwordsmanState(SwordsmanStateHandler stateHandler)
    {
        StateHandler = stateHandler;
    }

    public abstract void Enter();
    public abstract void Update(IInput input);
    public abstract void Exit();
}
