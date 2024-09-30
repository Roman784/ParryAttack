using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Enemy : Swordsman
{
    [SerializeField] private Player _player;

    private SwordsmanStateName _playerStateName;
    private bool _isInAction;

    private new void Awake()
    {
        base.Awake();

        _player.StateHandler.OnStateChanged.AddListener(OnPlayerStateChanged);

        _isInAction = false;

        Coroutines.StartRoutine(Life());
    }

    private void Update()
    {
    }

    private IEnumerator Life()
    {
        while (true)
        {
            DetermineState();

            yield return null;
        }
    }

    private void OnPlayerStateChanged(SwordsmanStateName stateName)
    {
        _playerStateName = stateName;
        DetermineState();
    }

    private void DetermineState()
    {
        if (_playerStateName == SwordsmanStateName.Idle)
        {
            if (Randomizer.TryChance(0.5f))
            {
                StateHandler.ChangeAttackState();
                return;
            }
        }
        else if (_playerStateName == SwordsmanStateName.Preattack)
        {
            if (Randomizer.TryChance(0.5f))
            {
                StateHandler.ChangeParryState();
                return;
            }
        }
        else if (_playerStateName == SwordsmanStateName.Attack)
        {
            if (Randomizer.TryChance(0.5f))
            {
                StateHandler.ChangeParryState();
                return;
            }
        }
        else if (_playerStateName == SwordsmanStateName.Parry)
        {
            if (Randomizer.TryChance(0.5f))
            {
                StateHandler.ChangeAttackState();
                return;
            }
        }

        //StateHandler.ChangeRandomState();
    }
}
