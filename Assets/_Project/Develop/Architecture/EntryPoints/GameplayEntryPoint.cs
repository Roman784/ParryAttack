using System.Collections;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : EntryPoint
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _enemySpawnPoint;
    
    private Player _player;
    private Enemy _enemy;

    private SwordsmanConfigBuilder _swordsmanConfigBuilder;

    private GameplayUI _gameplayUI;
    private GameplayUI _gameplayUIPrefab;

    [Inject]
    private void Construct(Player player, Enemy enemy, SwordsmanConfigBuilder swordsmanConfigBuilder, GameplayUI gameplayUIPrefab)
    {
        _player = player;
        _enemy = enemy;
        _swordsmanConfigBuilder = swordsmanConfigBuilder;
        _gameplayUIPrefab = gameplayUIPrefab;
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
    }

    private void InitSwordsmen()
    {
        _player.Init(_swordsmanConfigBuilder.BuildPlayer());
        _enemy.Init(_swordsmanConfigBuilder.BuildEnemy());

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
