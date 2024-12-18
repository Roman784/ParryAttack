using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Swordsman
{
    private EnemyConfig _enemyConfig;
    private float _stateUpdateCooldown;
    private float _attackProbability;
    private float _parryProbability;

    private Player _player;

    public void Init(EnemyConfig config, int positionIndex, Player player)
    {
        base.Init(config.SwordsmanConfig, positionIndex);

        _enemyConfig = config;
        _player = player;

        _stateUpdateCooldown = _enemyConfig.StateUpdateCooldown;
        _attackProbability = _enemyConfig.AttackProbability;
        _parryProbability = _enemyConfig.ParryProbability;

        _player.Positioning.OnMovedBack.AddListener(Positioning.MoveForward);

        Coroutines.StartRoutine(StateUpdate());
    }

    public override void PerformAttack()
    {
        _player.TakeHit();
    }

    private IEnumerator StateUpdate()
    {
        while (true)
        {
            DetermineState();

            yield return new WaitForSeconds(_stateUpdateCooldown);
        }
    }

    private void DetermineState()
    {
        if (!CanFight) return;

        var playerState = _player.StateHandler.CurrentStateName;

        // Define state transitions with their corresponding probabilities.
        // <Player state, (enemy response, probability)>
        var stateTransitions = new Dictionary<SwordsmanStateName, (SwordsmanStateName, float)>
        {
            { SwordsmanStateName.Idle, (SwordsmanStateName.Preattack, _attackProbability) },
            { SwordsmanStateName.Preattack, (SwordsmanStateName.Parry, _parryProbability) },
            { SwordsmanStateName.Attack, (SwordsmanStateName.Parry, _parryProbability) },
            { SwordsmanStateName.Parry, (SwordsmanStateName.Preattack, _attackProbability) },
            { SwordsmanStateName.Defeat, (SwordsmanStateName.Idle, 1f) }
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
