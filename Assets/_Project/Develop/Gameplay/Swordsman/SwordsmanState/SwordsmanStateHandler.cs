using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class SwordsmanStateHandler
{
    public UnityEvent<SwordsmanStateName> OnStateChanged = new();

    private Dictionary<SwordsmanStateName, SwordsmanState> _statesMap = new();
    private Dictionary<SwordsmanStateName, List<SwordsmanStateName>> _stateTransitions = new();

    private SwordsmanState _currentState;

    private Swordsman _swordsman;

    public SwordsmanStateHandler(Swordsman swordsman)
    {
        _swordsman = swordsman;

        InitStates();
        InitStateTransitions();

        DefaultState();
    }

    private void InitStates()
    {
        _statesMap[SwordsmanStateName.Idle] = new SwordsmanIdleState(this, _swordsman);
        _statesMap[SwordsmanStateName.Preattack] = new SwordsmanPreattackState(this, _swordsman);
        _statesMap[SwordsmanStateName.Attack] = new SwordsmanAttackState(this, _swordsman);
        _statesMap[SwordsmanStateName.Parry] = new SwordsmanParryState(this, _swordsman);
    }

    private void InitStateTransitions()
    {
        _stateTransitions[SwordsmanStateName.Idle] = new()
        {
            SwordsmanStateName.Preattack, SwordsmanStateName.Parry
        };
        _stateTransitions[SwordsmanStateName.Preattack] = new()
        {
            SwordsmanStateName.Attack, SwordsmanStateName.Parry
        };
        _stateTransitions[SwordsmanStateName.Attack] = new()
        {
            SwordsmanStateName.Idle, SwordsmanStateName.Preattack, SwordsmanStateName.Parry
        };
        _stateTransitions[SwordsmanStateName.Parry] = new()
        {
            SwordsmanStateName.Idle, SwordsmanStateName.Attack
        };
    }

    public void ChangeRandomState()
    {
        Randomizer.GetRandomValue<Action>(new() 
        {
            ChangeIdleState,
            ChangePreattackState,
            ChangeParryState
        }).Invoke();
    }

    public void ChangeIdleState() => ChangeState(SwordsmanStateName.Idle);
    public void ChangePreattackState() => ChangeState(SwordsmanStateName.Preattack);
    public void ChangeParryState() => ChangeState(SwordsmanStateName.Parry);

    public void ChangeState(bool isAttacking, bool isParrying)
    {
        var stateNamesByInput = new Dictionary<(bool, bool), SwordsmanStateName>()
        {
            { (false, false), SwordsmanStateName.Idle },
            { (true, false) , SwordsmanStateName.Preattack },
            { (false, true), SwordsmanStateName.Parry }
        };

        if (stateNamesByInput.TryGetValue((isAttacking, isParrying), out var transition))
            ChangeState(transition);
    }

    public void ChangeState(SwordsmanStateName newStateName)
    {
        if (!CanTransition(_currentState.Name, newStateName)) return;

        var state = GetState(newStateName);
        SetState(state);
    }

    private void DefaultState()
    {
        var State = GetState(SwordsmanStateName.Idle);
        SetState(State);
    }

    private bool CanTransition(SwordsmanStateName from, SwordsmanStateName to)
    {
        if (!_currentState.IsFinished) 
            return false;

        return _stateTransitions[from].Contains(to);
    }
    
    private SwordsmanState GetState(SwordsmanStateName name)
    {
        return _statesMap[name];
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
