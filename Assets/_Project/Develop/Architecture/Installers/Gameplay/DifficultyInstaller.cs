using UnityEngine;
using Zenject;

public class DifficultyInstaller : MonoInstaller
{
    [SerializeField] private DifficultyChangesConfig _changesConfig;

    public override void InstallBindings()
    {
        BindConfigs();
        BindAdjuster();
    }

    private void BindConfigs()
    {
        Container.Bind<DifficultyChangesConfig>().FromInstance(_changesConfig).AsTransient();
    }

    private void BindAdjuster()
    {
        Container.BindInterfacesAndSelfTo<DifficultyAdjuster>().AsSingle();
    }
}
