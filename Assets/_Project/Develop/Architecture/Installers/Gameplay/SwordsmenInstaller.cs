using UnityEngine;
using Zenject;

public class SwordsmenInstaller : MonoInstaller
{
    [SerializeField] private InitialSwordsmenConfig _initialConfig;

    [Space]

    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Enemy _enemyPrefab;

    public override void InstallBindings()
    {
        BindConfigs();
        BindConfigBuilder();
        BindFactory();
    }

    private void BindConfigs()
    {
        Container.Bind<InitialSwordsmenConfig>().FromInstance(_initialConfig).AsTransient();
    }

    private void BindConfigBuilder()
    {
        Container.BindInterfacesAndSelfTo<SwordsmenConfigBuilder>().AsSingle();
    }

    private void BindFactory()
    {
        Container.BindFactory<Player, Player.Factory>().FromComponentInNewPrefab(_playerPrefab);
        Container.BindFactory<Enemy, Enemy.Factory>().FromComponentInNewPrefab(_enemyPrefab);

        Container.Bind<SwordsmanFactory>().AsSingle();
    }
}
