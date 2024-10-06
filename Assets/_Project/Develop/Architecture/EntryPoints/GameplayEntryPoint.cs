using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : EntryPoint
{
    [SerializeField] private ThemeConfig[] _themeConfigs;

    private ArenaPositions _arenaPositions;

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
        yield return null;

        CreateUI();
        GenerateArena();
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

    private void GenerateArena()
    {
        int width = _levelTracker.CurrentLevelData.ArenaWidth;
        ThemeConfig themeConfig = _themeConfigs[Random.Range(0, _themeConfigs.Length)];

        ArenaGenerator generator = new ArenaGenerator(width, themeConfig);
        generator.Generate();

        _arenaPositions = generator.Positions;
    }

    private void InitSwordsmen()
    {
        _player.Init(_swordsmenConfigBuilder.BuildPlayer(), _arenaPositions);
        _enemy.Init(_swordsmenConfigBuilder.BuildEnemy(), _arenaPositions);
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
