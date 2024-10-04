using UnityEngine;
using Zenject;

public class DifficultyInstaller : MonoInstaller
{
    [SerializeField] private DifficultyChangesConfig _changesConfig;

    public override void InstallBindings()
    {
        BindConfigs();
    }

    private void BindConfigs()
    {
        Container.Bind<DifficultyChangesConfig>().FromInstance(_changesConfig).AsTransient();
    }
}
