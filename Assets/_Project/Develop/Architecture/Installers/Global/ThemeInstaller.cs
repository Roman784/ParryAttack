using UnityEngine;
using Zenject;

public class ThemeInstaller : MonoInstaller
{
    [SerializeField] private ThemesConfig _config;

    public override void InstallBindings()
    {
        BindConfigs();
        BindTracker();
        BindCreator();
        Debug.Log("Theme inst");
    }

    private void BindConfigs()
    {
        Container.Bind<ThemesConfig>().FromInstance(_config).AsTransient();
    }

    private void BindTracker()
    {
        Container.Bind<ThemeTracker>().AsSingle();
    }

    private void BindCreator()
    {
        Container.Bind<ThemeCreator>().AsTransient();
    }
}
