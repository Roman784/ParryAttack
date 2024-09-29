﻿using System;
using System.Collections.Generic;

public class SwordsmanStateHandler
{
    private Dictionary<Type, SwordsmanState> _statesMap;
    private SwordsmanState _currentState;

    private Swordsman _swordsman;

    public SwordsmanStateHandler(Swordsman swordsman)
    {
        _swordsman = swordsman;

        InitStates();
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, SwordsmanState>();

        _statesMap[typeof(SwordsmanIdleState)] = new SwordsmanIdleState(this, _swordsman);
        _statesMap[typeof(SwordsmanAttackState)] = new SwordsmanAttackState(this, _swordsman);
        _statesMap[typeof(SwordsmanParryState)] = new SwordsmanParryState(this, _swordsman);
    }

    public void Update(IInput input)
    {
        _currentState?.Update(input);
    }

    public void SetIdleState()
    {
        var State = GetState<SwordsmanIdleState>();
        SetState(State);
    }

    public void SetAttackState()
    {
        var State = GetState<SwordsmanAttackState>();
        SetState(State);
    }

    public void SetParryState()
    {
        var State = GetState<SwordsmanParryState>();
        SetState(State);
    }

    private SwordsmanState GetState<T>() where T : SwordsmanState
    {
        return _statesMap[typeof(T)];
    }

    private void SetState(SwordsmanState newState)
    {
        if (_currentState == newState) return;

        _currentState?.Exit();

        _currentState = newState;
        _currentState.Enter();
    }
}