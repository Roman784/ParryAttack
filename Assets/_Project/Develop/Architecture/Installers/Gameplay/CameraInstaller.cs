using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private CameraConfig _config;
    [SerializeField] private GameplayCamera _gameplayCamera;

    public override void InstallBindings()
    {
        BindConfigs();
        BindGameplayCamera();
    }

    private void BindConfigs()
    {
        Container.Bind<CameraConfig>().FromInstance(_config).AsTransient();
    }

    private void BindGameplayCamera()
    {
        Container.Bind<GameplayCamera>().FromInstance(_gameplayCamera).AsSingle();
    }
}
