using System.ComponentModel;
using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField] private UISoundsConfig _uiSoundsConfig;
    [SerializeField] private AudioSourcer _sourcerPrefab; 

    public override void InstallBindings()
    {
        BindConfigs();
        BindSorcerPrefab();
        BindPlayer();
    }

    private void BindConfigs()
    {
        Container.Bind<UISoundsConfig>().FromInstance(_uiSoundsConfig).AsTransient();
    }

    private void BindSorcerPrefab()
    {
        Container.Bind<AudioSourcer>().FromInstance(_sourcerPrefab).AsTransient();
    }

    private void BindPlayer()
    {
        Container.Bind<AudioPlayer>().AsSingle();
    }
}
