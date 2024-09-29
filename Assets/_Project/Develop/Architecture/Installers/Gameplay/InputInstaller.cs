using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
    }

    private void BindInput()
    {
        Container.Bind<PlayerInput>().To<KeyboadrInput>().AsSingle();
    }
}
