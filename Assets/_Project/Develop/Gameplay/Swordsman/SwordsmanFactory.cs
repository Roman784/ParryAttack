using Zenject;

public class SwordsmanFactory
{
    private Player.Factory _playerFactory;
    private Enemy.Factory _enemyFactory;

    [Inject]
    private void Construct(Player.Factory playerFactory, Enemy.Factory enemyFactory)
    {
        _playerFactory = playerFactory;
        _enemyFactory = enemyFactory;
    }

    public Player CreatePlayer()
    {
        return _playerFactory.Create();
    }

    public Enemy CreateEnemy()
    {
        return _enemyFactory.Create();
    }
}
