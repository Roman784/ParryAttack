using System.Collections;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : EntryPoint
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _enemySpawnPoint;
    
    private Player _player;
    private Enemy _enemy;

    private SwordsmenConfigBuilder _swordsmenConfigBuilder;

    private GameplayUI _gameplayUI;
    private GameplayUI _gameplayUIPrefab;

    private LevelTracker _levelTracker;

    [Inject]
    private void Construct(Player player, Enemy enemy, SwordsmenConfigBuilder swordsmenConfigBuilder, 
                           GameplayUI gameplayUIPrefab, LevelTracker levelTracker)
    {
        _player = player;
        _enemy = enemy;
        _swordsmenConfigBuilder = swordsmenConfigBuilder;
        _gameplayUIPrefab = gameplayUIPrefab;
        _levelTracker = levelTracker;
    }

    public override IEnumerator Run()
    {
        CreateUI();
        InitSwordsmen();
        StartCountdownTimer();

        yield return null;

        Debug.Log("Gameplay scene loaded");
    }

    private void CreateUI()
    {
        _gameplayUI = Instantiate(_gameplayUIPrefab);
        UIRoot.AttachSceneUI(_gameplayUI.transform);

        _gameplayUI.SetLevelData(_levelTracker.CurrentLevelData);
    }

    private void InitSwordsmen()
    {
        _player.Init(_swordsmenConfigBuilder.BuildPlayer());
        _enemy.Init(_swordsmenConfigBuilder.BuildEnemy());

        PositionSwordsmen();
    }

    private void PositionSwordsmen()
    {
        _player.transform.position = _playerSpawnPoint.position;
        _enemy.transform.position = _enemySpawnPoint.position;
    }

    private void StartCountdownTimer()
    {
        CountdownTimer countdownTimer = new(_gameplayUI.CountdownTimer);
        countdownTimer.Start(3);

        countdownTimer.OnTimerElapsed.AddListener(() =>
        {
            _player.AllowFight();
            _enemy.AllowFight();
        });
    }
}
