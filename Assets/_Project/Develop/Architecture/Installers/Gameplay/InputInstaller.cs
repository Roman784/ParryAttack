using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
    }

    private void BindInput()
    {
        Container.Bind<IInput>().To<KeyboadrInput>().AsSingle();
    }
}
