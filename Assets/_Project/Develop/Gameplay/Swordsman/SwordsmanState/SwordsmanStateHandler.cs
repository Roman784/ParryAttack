using System;
using System.Collections.Generic;
using System.Linq;

public class SwordsmanStateHandler
{
    private Dictionary<SwordsmanStateName, SwordsmanState> _statesMap = new();
    private Dictionary<SwordsmanStateName, List<SwordsmanStateName>> _stateTransitions = new();
    private List<SwordsmanStateName> _stateNames = new();

    private SwordsmanState _currentState;

    private Swordsman _swordsman;

    public SwordsmanStateHandler(Swordsman swordsman)
    {
        _swordsman = swordsman;

        InitStates();
        InitStateTransitions();
        InitStateNames();

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

    private void InitStateNames()
    {
        _stateNames = Enum.GetValues(typeof(SwordsmanStateName)).Cast<SwordsmanStateName>().ToList();
    }

    public bool IsParrying => CurrentStateName == SwordsmanStateName.Parry;
    public SwordsmanStateName CurrentStateName => _currentState.Name;

    public void ChangeRandomState()
    {
        var name = GetRandomStateNameForChanging(_stateNames);
        ChangeState(name);
    }

    public void ChangeRandomStateWithout(params SwordsmanStateName[] exemptNames)
    {
        var names = new List<SwordsmanStateName>(_stateNames);

        foreach (var exemptName in exemptNames)
        {
            if (names.Contains(exemptName))
                names.Remove(exemptName);
        }

        var name = GetRandomStateNameForChanging(names);
        ChangeState(name);
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

    private SwordsmanStateName GetRandomStateNameForChanging(List<SwordsmanStateName> origin)
    {
        var names = new List<SwordsmanStateName>(origin);
        names.Remove(SwordsmanStateName.Attack);

        return Randomizer.GetRandomValue(names);
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
    }
}
