using System.ComponentModel;
using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField] private AudioConfig _config;
    [SerializeField] private AudioSourcer _sourcerPrefab; 

    public override void InstallBindings()
    {
        BindConfigs();
        BindSorcerPrefab();
        BindPlayer();
    }

    private void BindConfigs()
    {
        Container.Bind<AudioConfig>().FromInstance(_config).AsTransient();
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
