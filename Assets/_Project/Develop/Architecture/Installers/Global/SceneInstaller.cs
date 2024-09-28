using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSceneLoader();
    }

    private void BindSceneLoader()
    {
        Container.Bind<SceneLoader>().AsSingle();
    }
}
