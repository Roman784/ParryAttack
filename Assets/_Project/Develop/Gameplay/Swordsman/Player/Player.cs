using UnityEngine;
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
    }

    public void Init(PlayerConfig config, ArenaPositions arenaPositions)
    {
        base.Init(config.SwordsmanConfig, arenaPositions);

        _input.OnAttackTrigger.AddListener(SetIsAttacking);
        _input.OnParryTrigger.AddListener(SetIsParrying);

        Positioning.SetPosition(arenaPositions.PlayerPosition);
        _enemy.Positioning.OnMovedBack.AddListener(Positioning.Move);
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
}
