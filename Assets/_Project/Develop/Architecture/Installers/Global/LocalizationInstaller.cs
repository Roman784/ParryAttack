using UnityEngine;
using Zenject;

public class LocalizationInstaller : MonoInstaller
{
    [SerializeField] private TranslationsConfig _config;

    public override void InstallBindings()
    {
        BindConfigs();
        BindTranslator();
    }

    private void BindConfigs()
    {
        Container.Bind<TranslationsConfig>().FromInstance(_config).AsTransient();
    }

    private void BindTranslator()
    {
        Container.Bind<Translator>().AsSingle();
    }
}
