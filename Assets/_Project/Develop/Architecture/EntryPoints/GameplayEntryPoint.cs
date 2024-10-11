using System.Collections;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : EntryPoint
{
    private GameplayUI _gameplayUI;
    private GameplayUI _gameplayUIPrefab;

    private SwordsmanFactory _swordsmanFactory;
    private SwordsmenConfigBuilder _swordsmenConfigBuilder;
    private Player _player;
    private Enemy _enemy;

    private LevelTracker _levelTracker;
    private LevelCreator _levelCreator;

    private GameplayCamera _camera;
    private ArenaPositions _arenaPositions;
    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SwordsmanFactory swordsmanFactory, SwordsmenConfigBuilder swordsmenConfigBuilder, 
                           GameplayUI gameplayUIPrefab, LevelTracker levelTracker, LevelCreator levelCreator,
                           GameplayCamera camera, SceneLoader sceneLoader)
    {
        _swordsmanFactory = swordsmanFactory;
        _swordsmenConfigBuilder = swordsmenConfigBuilder;
        _gameplayUIPrefab = gameplayUIPrefab;
        _levelTracker = levelTracker;
        _levelCreator = levelCreator;
        _camera = camera;
        _sceneLoader = sceneLoader;
    }

    public override IEnumerator Run()
    {
        yield return null;

        CreateUI();
        CreateLevel();
        CreateSwordsmen();
        CreateArenaPositionIndicator();
        InitCamera();
        InitFightResultHandler();
        StartCountdownTimer();

        yield return null;
    }

    private void CreateUI()
    {
        _gameplayUI = Instantiate(_gameplayUIPrefab);
        UIRoot.AttachSceneUI(_gameplayUI.transform);

        _gameplayUI.SetLevelData(_levelTracker.CurrentLevelData);
    }

    private void CreateLevel()
    {
        _arenaPositions = _levelCreator.Create();
    }

    private void CreateArenaPositionIndicator()
    {
        new ArenaPositionIndicator(_gameplayUI.ArenaPositionIndicatorView, _arenaPositions, _player, _enemy);
    }

    private void CreateSwordsmen()
    {
        _player = _swordsmanFactory.CreatePlayer();
        _enemy = _swordsmanFactory.CreateEnemy();

        int playerPositionIndex = _arenaPositions.Count / 2 - 1;
        int enemyPositionIndex = _arenaPositions.Count / 2;

        _player.Init(_swordsmenConfigBuilder.BuildPlayer(), playerPositionIndex, _enemy);
        _enemy.Init(_swordsmenConfigBuilder.BuildEnemy(), enemyPositionIndex, _player);
    }

    private void InitCamera()
    {
        _camera.Init(_player.transform, _enemy.transform);
    }

    private void InitFightResultHandler()
    {
        new FightResultHandler(_player, _enemy, _sceneLoader);
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
