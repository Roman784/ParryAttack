using System.Collections;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : EntryPoint
{
    [SerializeField] private CameraMovement _cameraMovement;

    private Player _player;
    private Enemy _enemy;

    private GameplayUI _gameplayUI;
    private GameplayUI _gameplayUIPrefab;

    private ThemeData _themeData;
    private ArenaPositions _arenaPositions;

    private SwordsmenConfigBuilder _swordsmenConfigBuilder;
    private LevelTracker _levelTracker;
    private ThemeCreator _themeCreator;

    [Inject]
    private void Construct(Player player, Enemy enemy, SwordsmenConfigBuilder swordsmenConfigBuilder, 
                           GameplayUI gameplayUIPrefab, LevelTracker levelTracker, ThemeCreator themeCreator)
    {
        _player = player;
        _enemy = enemy;
        _swordsmenConfigBuilder = swordsmenConfigBuilder;
        _gameplayUIPrefab = gameplayUIPrefab;
        _levelTracker = levelTracker;
        _themeCreator = themeCreator;
    }

    public override IEnumerator Run()
    {
        yield return null;

        CreateUI();
        CreateTheme();
        CreateArena();
        InitSwordsmen();
        InitCamera();
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

    private void CreateTheme()
    {
        _themeData = _themeCreator.Create();
    }

    private void CreateArena()
    {
        int width = _levelTracker.CurrentLevelData.ArenaWidth;

        ArenaCreator creator = new ArenaCreator(width, _themeData);
        _arenaPositions = creator.Create();
    }

    private void InitSwordsmen()
    {
        _player.Init(_swordsmenConfigBuilder.BuildPlayer(), _arenaPositions);
        _enemy.Init(_swordsmenConfigBuilder.BuildEnemy(), _arenaPositions);
    }

    private void InitCamera()
    {
        _cameraMovement.Init(_player.transform, _enemy.transform);
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
