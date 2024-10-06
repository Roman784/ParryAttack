using UnityEngine;
using Zenject;

public class ThemeInstaller : MonoInstaller
{
    [SerializeField] private ThemesConfig _config;

    public override void InstallBindings()
    {
        BindConfigs();
    }

    private void BindConfigs()
    {
        Container.Bind<ThemesConfig>().FromInstance(_config).AsTransient();
    }
}
