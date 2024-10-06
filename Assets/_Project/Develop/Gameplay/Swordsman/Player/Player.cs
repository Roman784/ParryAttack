using UnityEngine;
using Zenject;

public class Player : Swordsman
{
    private PlayerInput _input;
    private Enemy _enemy;

    [Inject]
    private void Construct(PlayerInput input)
    {
        _input = input;
    }

    public void Init(PlayerConfig config, Enemy enemy)
    {
        base.Init(config.SwordsmanConfig);

        _enemy = enemy;

        _input.OnAttackTrigger.AddListener(SetIsAttacking);
        _input.OnParryTrigger.AddListener(SetIsParrying);

        Positioning.SetInitialPositionForPlayer();
        _enemy.Positioning.OnMovedBack.AddListener(Positioning.MoveForward);
    }

    private void Update()
    {
        if (CanFight)
            _input?.Handle();
    }

    public override void PerformAttack()
    {
        _enemy.TakeHit();
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

    public class Factory : PlaceholderFactory<Player>
    {
    }
}
