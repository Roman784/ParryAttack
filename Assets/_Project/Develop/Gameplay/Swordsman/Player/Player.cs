using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : Swordsman
{
    private PlayerInput _input;

    [Inject]
    private void Construct(PlayerInput input)
    {
        _input = input;

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
