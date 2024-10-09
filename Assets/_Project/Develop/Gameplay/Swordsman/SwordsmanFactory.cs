using Zenject;

public class SwordsmanFactory
{
    private DiContainer _diContainer;
    private Player _playerPrefab;
    private Enemy _enemyPrefab;

    [Inject]
    private void Construct(DiContainer diContainer, Player playerPrefab, Enemy enemyPrefab)
    {
        _diContainer = diContainer;
        _playerPrefab = playerPrefab;
        _enemyPrefab = enemyPrefab;
    }

    public Player CreatePlayer()
    {
        return _diContainer.InstantiatePrefab(_playerPrefab).GetComponent<Player>();
    }

    public Enemy CreateEnemy()
    {
        return _diContainer.InstantiatePrefab(_enemyPrefab).GetComponent<Enemy>();
    }
}
