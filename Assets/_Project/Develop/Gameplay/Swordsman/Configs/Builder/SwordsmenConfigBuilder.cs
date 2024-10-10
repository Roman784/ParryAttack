using Zenject;

public sealed class SwordsmenConfigBuilder
{
    private PlayerConfigBuilder _playerBuilder;
    private EnemyConfigBuilder _enemyBuilder;

    [Inject]
    private void Construct(PlayerConfig initialPlayerConfig, EnemyConfig initialEnemyConfig, 
                           PlayerProgressionConfig playerProgressionConfig, EnemyProgressionConfig enemyProgressionConfig,
                           LevelTracker levelTracker)
    {
        float levelProgress = levelTracker.Progress;

        _playerBuilder = new PlayerConfigBuilder(initialPlayerConfig, playerProgressionConfig, levelProgress);
        _enemyBuilder = new EnemyConfigBuilder(initialEnemyConfig, enemyProgressionConfig, levelProgress);
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
