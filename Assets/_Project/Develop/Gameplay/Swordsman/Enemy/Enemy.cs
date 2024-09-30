using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Swordsman
{
    [SerializeField] private Player _player;
    private SwordsmanStateName _playerStateName;

    private float _stateUpdateColdown;
    private float _attackProbability;
    private float _parryProbability;

    private new void Awake()
    {
        base.Awake();

        _player.StateHandler.OnStateChanged.AddListener(OnPlayerStateChanged);

        Coroutines.StartRoutine(StateUpdate());
    }

    private IEnumerator StateUpdate()
    {
        while (true)
        {
            DetermineState();

            yield return new WaitForSeconds(_stateUpdateColdown);
        }
    }

    private void OnPlayerStateChanged(SwordsmanStateName stateName)
    {
        _playerStateName = stateName;
        DetermineState();
    }

    private void DetermineState()
    {
        // Define state transitions with their corresponding probabilities.
        var stateTransitions = new Dictionary<SwordsmanStateName, (SwordsmanStateName, float)>
        {
            { SwordsmanStateName.Idle, (SwordsmanStateName.Attack, _attackProbability) },
            { SwordsmanStateName.Preattack, (SwordsmanStateName.Parry, _parryProbability) },
            { SwordsmanStateName.Attack, (SwordsmanStateName.Parry, _parryProbability) },
            { SwordsmanStateName.Parry, (SwordsmanStateName.Attack, _attackProbability) }
        };

        // Check if a transition exists for the current state.
        if (stateTransitions.TryGetValue(_playerStateName, out var transition))
        {
            if (Randomizer.TryProbability(transition.Item2))
            {
                StateHandler.ChangeState(transition.Item1);
                return;
            }
        }

        // If no transition exists, change to a random state.
        StateHandler.ChangeRandomState();
    }
}
