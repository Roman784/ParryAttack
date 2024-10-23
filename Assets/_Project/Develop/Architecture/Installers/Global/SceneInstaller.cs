using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSceneLoader();
        Debug.Log("Scene inst");
    }

    private void BindSceneLoader()
    {
        Container.Bind<SceneLoader>().AsSingle();
    }
}
