using UnityEngine;
using Zenject;

public class SwordsmenInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig _initialPlayerConfig;
    [SerializeField] private EnemyConfig _initialEnemyConfig;

    [Space]

    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Enemy _enemyPrefab;

    public override void InstallBindings()
    {
        BindConfigs();
        BindSwordsmenPrefabs();
        BindConfigBuilder();
        BindFactory();
    }

    private void BindConfigs()
    {
        Container.Bind<PlayerConfig>().FromInstance(_initialPlayerConfig).AsTransient();
        Container.Bind<EnemyConfig>().FromInstance(_initialEnemyConfig).AsTransient();
    }

    private void BindSwordsmenPrefabs()
    {
        Container.Bind<Player>().FromInstance(_playerPrefab).AsTransient();
        Container.Bind<Enemy>().FromInstance(_enemyPrefab).AsTransient();
    }

    private void BindConfigBuilder()
    {
        Container.BindInterfacesAndSelfTo<SwordsmenConfigBuilder>().AsSingle();
    }

    private void BindFactory()
    {
        // Container.BindFactory<Player, Player.Factory>().FromComponentInNewPrefab(_playerPrefab);
        // Container.BindFactory<Enemy, Enemy.Factory>().FromComponentInNewPrefab(_enemyPrefab);

        Container.Bind<SwordsmanFactory>().AsSingle();
    }
}
