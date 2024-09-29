using System;
using UnityEngine;
using Zenject;

public class Player : Swordsman
{
    private bool _isAttacking;
    private bool _isParrying;

    [Inject]
    private void Construct(PlayerInput input)
    {
        Input = input;

        input.OnAttackTrigger.AddListener(SetIsAttacking);
        input.OnParryTrigger.AddListener(SetIsParrying);
    }

    private new void Awake()
    {
        base.Awake();

        _isAttacking = false;
        _isParrying = false;
    }

    private void Update()
    {
        Input?.Update();
    }

    private void SetIsAttacking(bool isKeyPressed)
    {
        if (isKeyPressed == _isAttacking) return;

        _isAttacking = isKeyPressed;
        ChangeState();
    }

    private void SetIsParrying(bool isKeyPressed)
    {
        if (isKeyPressed == _isParrying) return;

        _isParrying = isKeyPressed;
        ChangeState();
    }

    private void ChangeState()
    {
        StateHandler.ChangeState(_isAttacking, _isParrying);
    }
}
