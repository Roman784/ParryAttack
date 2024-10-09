using System.Collections;
using Zenject;

public class LevelListEntryPoint : EntryPoint
{
    private LevelListUI _levelListUI;
    private LevelListUI _levelListUIPrefab;

    [Inject]
    private void Construct(LevelListUI levelListUIPrefab)
    {
        _levelListUIPrefab = levelListUIPrefab;
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
}
