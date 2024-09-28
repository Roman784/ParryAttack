using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private UIRoot _uiRoot;
    [SerializeField] private GameplayUI _gameplayUI;

    public override void InstallBindings()
    {
        BindUIRoot();
        BindGameplayUI();
    }

    private void BindUIRoot()
    {
        Container.Bind<UIRoot>().FromComponentInNewPrefab(_uiRoot).AsSingle();
    }

    private void BindGameplayUI()
    {
        Container.Bind<GameplayUI>().FromInstance(_gameplayUI).AsTransient();
    }
}
