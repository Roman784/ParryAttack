using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private CountdownTimerView _countdownTimer;

    [SerializeField] private TMP_Text _enemyNameView;

    public CountdownTimerView CountdownTimer => _countdownTimer;

    public void SetLevelData(LevelData data)
    {
        _enemyNameView.text = data.EnemyName;
    }
}
