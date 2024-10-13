using UnityEngine;
using Zenject;

public class StorageInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
            return;
            
        BindJsonStorage();
    }

    private void BindJsonStorage()
    {
        Container.Bind<Storage>().To<JsonStorage>().AsSingle();
    }
}
