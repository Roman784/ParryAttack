using System.Collections;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : EntryPoint
{
    [SerializeField] private SwordsmanConfigBuilder _swordsmanConfigBuilder;

    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _enemySpawnPoint;
    
    private Player _player;
    private Enemy _enemy;

    private GameplayUI _gameplayUI;

    [Inject]
    private void Construct(Player player, Enemy enemy, GameplayUI gameplayUI)
    {
        _player = player;
        _enemy = enemy;
        _gameplayUI = gameplayUI;
    }

    public override IEnumerator Run()
    {
        GameplayUI gameplayUI = Instantiate(_gameplayUI);
        UIRoot.AttachSceneUI(gameplayUI.transform);

        InitSwordsmen();

        yield return null;

        Debug.Log("Gameplay scene loaded");
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
}
