using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private CountdownTimerView _countdownTimer;

    public CountdownTimerView CountdownTimer => _countdownTimer;
}
