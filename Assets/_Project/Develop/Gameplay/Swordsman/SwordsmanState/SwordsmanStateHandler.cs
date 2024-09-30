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

    public void ChangeRandomState()
    {
        Randomizer.GetRandomValue<Action>(new() 
        {
            ChangeIdleState,
            ChangeAttackState,
            ChangeParryState
        }).Invoke();
    }

    public void ChangeIdleState() => ChangeState(SwordsmanStateName.Idle);
    public void ChangeAttackState() => ChangeState(SwordsmanStateName.Attack);
    public void ChangeParryState() => ChangeState(SwordsmanStateName.Parry);

    public void ChangeState(bool isAttacking, bool isParrying)
    {
        var stateTransitions = new Dictionary<(bool, bool), SwordsmanStateName>()
        {
            { (false, false), SwordsmanStateName.Idle },
            { (true, false) , SwordsmanStateName.Attack },
            { (false, true), SwordsmanStateName.Parry }
        };

        if (stateTransitions.TryGetValue((isAttacking, isParrying), out var transition))
            ChangeState(transition);
    }

    public void ChangeState(SwordsmanStateName stateName)
    {
        _currentState?.ChangeState(stateName);
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
