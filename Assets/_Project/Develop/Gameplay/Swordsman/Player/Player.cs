using Zenject;

public class Player : Swordsman
{
    [Inject]
    private void Construct(IInput input)
    {
        Input = input;
    }

    private new void Awake()
    {
        base.Awake();
    }
}
