using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private UIRoot _uiRoot;
    [SerializeField] private GameplayUI _gameplayUI;
    [SerializeField] private LevelListUI _levelListUI;

    public override void InstallBindings()
    {
        BindUIRoot();
        BindGameplayUI();
        BindLevelListUI();
    }

    private void BindUIRoot()
    {
        Container.Bind<UIRoot>().FromComponentInNewPrefab(_uiRoot).AsSingle();
    }

    private void BindGameplayUI()
    {
        Container.Bind<GameplayUI>().FromInstance(_gameplayUI).AsTransient();
    }

    private void BindLevelListUI()
    {
        Container.Bind<LevelListUI>().FromInstance(_levelListUI).AsTransient();
    }
}
