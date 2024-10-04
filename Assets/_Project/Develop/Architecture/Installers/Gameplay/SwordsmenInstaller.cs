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
        BindSwordsmen();
    }

    private void BindConfigs()
    {
        Container.Bind<InitialSwordsmenConfig>().FromInstance(_initialConfig).AsTransient();
    }

    private void BindConfigBuilder()
    {
        Container.BindInterfacesAndSelfTo<SwordsmanConfigBuilder>().AsSingle();
    }

    private void BindSwordsmen()
    {
        Container.Bind<Player>().FromComponentInNewPrefab(_playerPrefab).AsSingle();
        Container.Bind<Enemy>().FromComponentInNewPrefab(_enemyPrefab).AsSingle();
    }
}
