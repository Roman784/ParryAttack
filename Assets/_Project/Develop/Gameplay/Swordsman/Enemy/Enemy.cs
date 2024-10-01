using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : Swordsman
{
    [Space]

    [SerializeField] private EnemyConfig _enemyConfig;

    private float _stateUpdateCooldown;
    private float _attackProbability;
    private float _parryProbability;

    private Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    private new void Awake()
    {
        base.Awake();

        _stateUpdateCooldown = _enemyConfig.StateUpdateCooldown;
        _attackProbability = _enemyConfig.AttackProbability;
        _parryProbability = _enemyConfig.ParryProbability;

        Coroutines.StartRoutine(StateUpdate());
    }

    public override void PerformAttack()
    {
        _player.TakeDamage();
    }

    private IEnumerator StateUpdate()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            DetermineState();

            yield return new WaitForSeconds(_stateUpdateCooldown);
        }
    }

    private void DetermineState()
    {
        var playerState = _player.StateHandler.CurrentStateName;

        // Define state transitions with their corresponding probabilities.
        // <Player state, (enemy response, probability)>
        var stateTransitions = new Dictionary<SwordsmanStateName, (SwordsmanStateName, float)>
        {
            { SwordsmanStateName.Idle, (SwordsmanStateName.Preattack, _attackProbability) },
            { SwordsmanStateName.Preattack, (SwordsmanStateName.Parry, _parryProbability) },
            { SwordsmanStateName.Attack, (SwordsmanStateName.Parry, _parryProbability) },
            { SwordsmanStateName.Parry, (SwordsmanStateName.Preattack, _attackProbability) }
        };

        // Check if a transition exists for the current state.
        if (stateTransitions.TryGetValue(playerState, out var transition))
        {
            if (Randomizer.TryProbability(transition.Item2))
            {
                StateHandler.ChangeState(transition.Item1);
                return;
            }
            else
            {
                StateHandler.ChangeRandomStateWithout(transition.Item1);
                return;
            }
        }

        // If no transition exists, change to a random state.
        StateHandler.ChangeRandomStateWithout();
    }
}
