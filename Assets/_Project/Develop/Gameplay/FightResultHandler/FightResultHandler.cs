using System.Collections;
using UnityEngine;

public class FightResultHandler
{
    private FightResultHandlerView _view;
    private Player _player;
    private Enemy _enemy;
    private LevelTracker _levelTracker;
    private SceneLoader _sceneLoader;
    private Storage _storage;
    private AudioPlayer _audioPlayer;

    public FightResultHandler(FightResultHandlerView view, Player player, Enemy enemy, 
                              LevelTracker levelTracker, SceneLoader sceneLoader, 
                              Storage storage, AudioPlayer audioPlayer)
    {
        _view = view;
        _player = player;
        _enemy = enemy;
        _levelTracker = levelTracker;
        _sceneLoader = sceneLoader;
        _storage = storage;
        _audioPlayer = audioPlayer;

        _player.OnDefeated.AddListener(HandlePlayerDefeat);
        _enemy.OnDefeated.AddListener(HandleEnemyDefeat);

        _view.OnRetryButtonClicked.AddListener(RestartLevel);
        _view.OnNexLevelButtonClicked.AddListener(OpenNextLevel);
    }

    private void HandlePlayerDefeat()
    {
        ForbidFight();
        _view.ShowRetryButton();
    }

    private void HandleEnemyDefeat()
    {
        ForbidFight();
        _view.ShowNextLevelButton();

        SetLastLevel();
    }

    private void ForbidFight()
    {
        _player.ForbidFight();
        _enemy.ForbidFight();
    }

    private void RestartLevel()
    {
        _audioPlayer.UISounds.PlayButtonClick();
        _sceneLoader.LoadGameplay();
    }

    private void OpenNextLevel()
    {
        _audioPlayer.UISounds.PlayButtonClick();
        _levelTracker.IncreaseCurrentNumber();
        _sceneLoader.LoadGameplay();
    }

    private void SetLastLevel()
    {
        if (_levelTracker.Current > _storage.GameData.LastCompletedLevel)
            _storage.SetLastCompletedLevel(_levelTracker.Current);
    }
}
