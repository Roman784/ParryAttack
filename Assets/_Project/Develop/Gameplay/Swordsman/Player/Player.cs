using Zenject;

public class Player : Swordsman
{
    private PlayerInput _input;
    private Enemy _enemy;

    [Inject]
    private void Construct(PlayerInput input, Enemy enemy)
    {
        _input = input;
        _enemy = enemy;

        input.OnAttackTrigger.AddListener(SetIsAttacking);
        input.OnParryTrigger.AddListener(SetIsParrying);
    }

    private new void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        _input?.Handle();
    }

    public override void PerformAttack()
    {
        _enemy.TakeDamage();
    }

    private void SetIsAttacking(bool isKeyPressed)
    {
        if (isKeyPressed == IsAttacking) return;

        IsAttacking = isKeyPressed;
        ChangeState();
    }

    private void SetIsParrying(bool isKeyPressed)
    {
        if (isKeyPressed == IsParrying) return;

        IsParrying = isKeyPressed;
        ChangeState();
    }

    private void ChangeState()
    {
        StateHandler.ChangeState(IsAttacking, IsParrying);
    }
}
