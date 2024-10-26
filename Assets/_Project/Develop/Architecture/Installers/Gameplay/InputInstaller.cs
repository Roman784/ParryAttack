using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer ||  Application.platform == RuntimePlatform.Android || Application.isMobilePlatform)
            BindTouchscreenInput();
        else
            BindKeyboarInput();
    }

    private void BindKeyboarInput()
    {
        Container.Bind<PlayerInput>().To<KeyboadrInput>().AsSingle();
    }

    private void BindTouchscreenInput()
    {
        Container.Bind<PlayerInput>().To<TouchscreenInput>().AsSingle();
    }
}
