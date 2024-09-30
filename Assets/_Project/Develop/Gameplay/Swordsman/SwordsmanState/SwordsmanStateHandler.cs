using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class SwordsmanStateHandler
{
    public UnityEvent<SwordsmanStateName> OnStateChanged = new();

    private Dictionary<SwordsmanStateName, SwordsmanState> _statesMap;
    private SwordsmanState _currentState;

    private Swordsman _swordsman;

    public SwordsmanStateHandler(Swordsman swordsman)
    {
        _swordsman = swordsman;

        InitStates();
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<SwordsmanStateName, SwordsmanState>();

        _statesMap[SwordsmanStateName.Idle] = new SwordsmanIdleState(this, _swordsman);
        _statesMap[SwordsmanStateName.Preattack] = new SwordsmanPreattackState(this, _swordsman);
        _statesMap[SwordsmanStateName.Attack] = new SwordsmanAttackState(this, _swordsman);
        _statesMap[SwordsmanStateName.Parry] = new SwordsmanParryState(this, _swordsman);
    }

    public void ChangeState(bool isAttacking, bool isParrying)
    {
        _currentState?.ChangeState(isAttacking, isParrying);
    }

    public void SetIdleState()
    {
        var State = GetState(SwordsmanStateName.Idle);
        SetState(State);
    }

    public void SetPreattackState()
    {
        var State = GetState(SwordsmanStateName.Preattack);
        SetState(State);
    }

    public void SetAttackState()
    {
        var State = GetState(SwordsmanStateName.Attack);
        SetState(State);
    }

    public void SetParryState()
    {
        var State = GetState(SwordsmanStateName.Parry);
        SetState(State);
    }

    private SwordsmanState GetState(SwordsmanStateName state)
    {
        return _statesMap[state];
    }

    private void SetState(SwordsmanState newState)
    {
        if (newState == _currentState) return;

        _currentState?.Exit();

        _currentState = newState;
        _currentState.Enter();

        OnStateChanged.Invoke(_currentState.Name);
    }
}
