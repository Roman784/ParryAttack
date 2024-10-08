using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private UIRoot _uiRoot;
    [SerializeField] private GameplayUI _gameplayUI;
    [SerializeField] private EnemySelectionUI _enemySelectionUI;

    public override void InstallBindings()
    {
        BindUIRoot();
        BindGameplayUI();
        BindEnemySelectionUI();
    }

    private void BindUIRoot()
    {
        Container.Bind<UIRoot>().FromComponentInNewPrefab(_uiRoot).AsSingle();
    }

    private void BindGameplayUI()
    {
        Container.Bind<GameplayUI>().FromInstance(_gameplayUI).AsTransient();
    }

    private void BindEnemySelectionUI()
    {
        Container.Bind<EnemySelectionUI>().FromInstance(_enemySelectionUI).AsTransient();
    }
}
