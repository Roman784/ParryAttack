using UnityEngine;
using Zenject;

public class ProgressionInstaller : MonoInstaller
{
    [SerializeField] private PlayerProgressionConfig _playerConfig;
    [SerializeField] private EnemyProgressionConfig _enemyConfig;

    public override void InstallBindings()
    {
        BindConfigs();
    }

    private void BindConfigs()
    {
        Container.Bind<PlayerProgressionConfig>().FromInstance(_playerConfig).AsTransient();
        Container.Bind<EnemyProgressionConfig>().FromInstance(_enemyConfig).AsTransient();
    }
}
