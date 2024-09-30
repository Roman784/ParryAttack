using System.Collections;
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

        //Coroutines.StartRoutine(Life());
    }

    private void Update()
    {
        if (_playerStateName == SwordsmanStateName.Preattack || _playerStateName == SwordsmanStateName.Attack)
        {
            Debug.Log("Parry");
            StateHandler.ChangeState(false, true);
        }
        else if (_playerStateName == SwordsmanStateName.Idle || _playerStateName == SwordsmanStateName.Parry)
        {
            Debug.Log("Preattack");
            StateHandler.ChangeState(true, false);
        }
    }

    private IEnumerator Life()
    {
        while (true)
        {
            if (!_isInAction)
            {
                /*int r = Random.Range(0, 100);

                if (r > 95)
                {
                    Coroutines.StartRoutine(Attack());
                }
                else if (r > 80)
                {
                    Coroutines.StartRoutine(Parry());
                }
                else
                {
                    StateHandler.SetIdleState();
                }*/

                if (_playerStateName == SwordsmanStateName.Preattack || _playerStateName == SwordsmanStateName.Attack)
                {
                    Debug.Log("Parry");
                    StateHandler.SetParryState();
                }
                else if (_playerStateName == SwordsmanStateName.Idle)
                {
                    Debug.Log("Attack");
                    StateHandler.SetPreattackState();
                }
                else if (_playerStateName == SwordsmanStateName.Parry)
                {
                    Debug.Log("Idle");
                    StateHandler.SetIdleState();
                }
            }

            yield return null;
        }
    }

    private void OnPlayerStateChanged(SwordsmanStateName stateName)
    {
        _playerStateName = stateName;
        /*if (_isInAction) return;

        if (stateName == SwordsmanStateName.Preattack || stateName == SwordsmanStateName.Attack)
        {
            Debug.Log("Parry");
            Coroutines.StartRoutine(Parry());
        }
        else if (stateName == SwordsmanStateName.Parry)
        {
            Debug.Log("Idle");
            StateHandler.ChangeState(false, false);
        }
        else if (stateName == SwordsmanStateName.Idle)
        {
            Debug.Log("Attack");
            Coroutines.StartRoutine(Attack());
        }*/
    }

    private IEnumerator Attack()
    {
        _isInAction = true;

        StateHandler.SetPreattackState();

        yield return new WaitForSeconds(Config.AttributesConfig.PreattackDuration);

        StateHandler.SetAttackState();

        yield return new WaitForSeconds(Config.AttributesConfig.AttackDuration);

        _isInAction = false;
    }

    private IEnumerator Parry()
    {
        _isInAction = true;
        StateHandler.SetParryState();

        yield return new WaitForSeconds(2f);

        _isInAction = false;
        StateHandler.SetIdleState();
    }
}
