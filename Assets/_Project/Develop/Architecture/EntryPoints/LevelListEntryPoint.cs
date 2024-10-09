using System.Collections;
using Zenject;

public class LevelListEntryPoint : EntryPoint
{
    private LevelListUI _levelListUI;
    private LevelListUI _levelListUIPrefab;

    private LevelListConfig _levelListConfig;
    
    private SceneLoader _sceneLoader;
    private LevelTracker _levelTracker;

    [Inject]
    private void Construct(LevelListUI levelListUIPrefab, LevelListConfig levelListConfig,
                           SceneLoader sceneLoader, LevelTracker levelTracker)
    {
        _levelListUIPrefab = levelListUIPrefab;
        _levelListConfig = levelListConfig;
        _sceneLoader = sceneLoader;
        _levelTracker = levelTracker;
    }

    public override IEnumerator Run()
    {
        yield return null;

        CreateUI();
        CreateLevelButtons();
    }

    private void CreateUI()
    {
        _levelListUI = Instantiate(_levelListUIPrefab);
        UIRoot.AttachSceneUI(_levelListUI.transform);
    }

    private void CreateLevelButtons()
    {
        LevelListMenu levelListMenu = new(_levelListUI, _levelListConfig, _sceneLoader, _levelTracker);
        levelListMenu.CreateButtons();
    }
}
