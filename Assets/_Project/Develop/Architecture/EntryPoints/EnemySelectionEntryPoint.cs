using System.Collections;
using Zenject;

public class EnemySelectionEntryPoint : EntryPoint
{
    private EnemySelectionUI _enemySelectionUI;
    private EnemySelectionUI _enemySelectionUIPrefab;

    [Inject]
    private void Construct(EnemySelectionUI enemySelectionUIPrefab)
    {
        _enemySelectionUIPrefab = enemySelectionUIPrefab;
    }

    public override IEnumerator Run()
    {
        yield return null;

        CreateUI();
    }

    private void CreateUI()
    {
        _enemySelectionUI = Instantiate(_enemySelectionUIPrefab);
        UIRoot.AttachSceneUI(_enemySelectionUI.transform);
    }
}
