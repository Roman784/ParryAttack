using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private ArenaPositionIndicatorView _arenaPositionIndicatorView;
    [SerializeField] private CountdownTimerView _countdownTimer;
    [SerializeField] private FightResultHandlerView _fightResultHandlerView;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private EducationView _educationView;

    [SerializeField] private TMP_Text _enemyNameView;

    public ArenaPositionIndicatorView ArenaPositionIndicatorView => _arenaPositionIndicatorView;
    public CountdownTimerView CountdownTimer => _countdownTimer;
    public FightResultHandlerView FightResultHandlerView => _fightResultHandlerView;
    public EducationView EducationView => _educationView;

    public void Init(SceneLoader sceneLoader, AudioPlayer audioPlayer)
    {
        _pauseMenu.Init(sceneLoader, audioPlayer);
    }

    public void SetLevelData(LevelData data)
    {
        _enemyNameView.text = data.EnemyData.Name;
    }
}
