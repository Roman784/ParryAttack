using Zenject;

public sealed class SwordsmenConfigBuilder
{
    private PlayerConfigBuilder _playerBuilder;
    private EnemyConfigBuilder _enemyBuilder;

    [Inject]
    private void Construct(InitialSwordsmenConfig initialConfig, DifficultyAdjuster difficultyAdjuster, LevelTracker levelTracker)
    {
        _playerBuilder = new PlayerConfigBuilder(initialConfig);
        _enemyBuilder = new EnemyConfigBuilder(initialConfig, difficultyAdjuster, levelTracker.CurrentLevelData);
    }

    public PlayerConfig BuildPlayer()
    {
        return _playerBuilder.Build();
    }

    public EnemyConfig BuildEnemy()
    {
        return _enemyBuilder.Build();
    }
}
