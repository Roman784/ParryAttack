using System;
using System.Collections.Generic;
using System.Linq;

public class SwordsmanStateHandler
{
    // All states.
    private Dictionary<SwordsmanStateName, SwordsmanState> _statesMap = new();
    // A graph of possible transitions, from which state it is possible to change to another state.
    private Dictionary<SwordsmanStateName, List<SwordsmanStateName>> _stateTransitions = new();
    // States to which you can change from any other state.
    private List<SwordsmanStateName> _statesForChanging = new();

    private SwordsmanState _currentState;

    private Swordsman _swordsman;

    public SwordsmanStateHandler(Swordsman swordsman)
    {
        _swordsman = swordsman;

        InitStates();
        InitStateTransitions();
        InitStatesForChanging();

        SetDefaultState();
    }

    private void InitStates()
    {
        _statesMap[SwordsmanStateName.Idle] = new SwordsmanIdleState(this, _swordsman);
        _statesMap[SwordsmanStateName.Preattack] = new SwordsmanPreattackState(this, _swordsman);
        _statesMap[SwordsmanStateName.Attack] = new SwordsmanAttackState(this, _swordsman);
        _statesMap[SwordsmanStateName.Parry] = new SwordsmanParryState(this, _swordsman);
        _statesMap[SwordsmanStateName.Defeat] = new SwordsmanDefeatState(this, _swordsman);
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
            SwordsmanStateName.Idle, SwordsmanStateName.Preattack
        };
    }

    private void InitStatesForChanging()
    {
        _statesForChanging.Add(SwordsmanStateName.Idle);
        _statesForChanging.Add(SwordsmanStateName.Parry);
        _statesForChanging.Add(SwordsmanStateName.Preattack);
    }

    public bool IsParrying => CurrentStateName == SwordsmanStateName.Parry;
    public SwordsmanStateName CurrentStateName => _currentState.Name;

    // It is possible to go to a defeat state instantly from any other state.
    // Therefore, it is not in the transition graph.
    public void SetDefeatState()
    {
        var state = GetState(SwordsmanStateName.Defeat);
        SetState(state);
    }

    public void ChangeRandomStateWithout(params SwordsmanStateName[] exemptNames)
    {
        var names = new List<SwordsmanStateName>(_statesForChanging);

        foreach (var exemptName in exemptNames)
        {
            if (names.Contains(exemptName))
                names.Remove(exemptName);
        }

        var name = Randomizer.GetRandomValue(names);
        ChangeState(name);
    }

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

    private void SetDefaultState()
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
    }
}
