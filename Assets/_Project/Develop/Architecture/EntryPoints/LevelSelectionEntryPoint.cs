using System.Collections;
using Zenject;

public class LevelListEntryPoint : EntryPoint
{
    private LevelListUI _levelListUI;
    private LevelListUI _levelListUIPrefab;

    private LevelListConfig _levelListConfig;

    [Inject]
    private void Construct(LevelListUI levelListUIPrefab, LevelListConfig levelListConfig)
    {
        _levelListUIPrefab = levelListUIPrefab;
        _levelListConfig = levelListConfig;
    }

    public override IEnumerator Run()
    {
        yield return null;

        CreateUI();
    }

    private void CreateUI()
    {
        _levelListUI = Instantiate(_levelListUIPrefab);
        UIRoot.AttachSceneUI(_levelListUI.transform);
    }

    private void CreateLevelButtons()
    {
        LevelListMenu levelListMenu = new(_levelListUI, _levelListConfig);
        levelListMenu.CreateButtons();
    }
}
