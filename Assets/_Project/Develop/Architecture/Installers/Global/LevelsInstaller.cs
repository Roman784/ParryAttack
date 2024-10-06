using UnityEngine;
using Zenject;

public class LevelsInstaller : MonoInstaller
{
    [SerializeField] private LevelListConfig _levelListConfig;

    public override void InstallBindings()
    {
        BindConfigs();
        BindLevelTracker();
        BindCreator();
    }

    private void BindConfigs()
    {
        Container.Bind<LevelListConfig>().FromInstance(_levelListConfig).AsTransient();
    }

    private void BindLevelTracker()
    {
        Container.BindInterfacesAndSelfTo<LevelTracker>().AsSingle();
    }

    private void BindCreator()
    {
        Container.Bind<LevelCreator>().AsSingle();
    }
}
