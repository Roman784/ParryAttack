using System.Collections;
using Zenject;

public class ThemeSelectionEntryPoint : EntryPoint
{
    private ThemeSelectionUI _themeSelectionUI;
    private ThemeSelectionUI _themeSelectionUIPrefab;

    private ThemeCreator _themeCreator;
    private ThemeTracker _themeTracker;

    [Inject]
    private void Construct(ThemeSelectionUI themeSelectionUIPrefab, ThemeCreator themeCreator, ThemeTracker themeTracker)
    {
        _themeSelectionUIPrefab = themeSelectionUIPrefab;
        _themeCreator = themeCreator;
        _themeTracker = themeTracker;
    }

    public override IEnumerator Run()
    {
        yield return null;

        CreateUI();
        CreateThemes();
    }

    private void CreateUI()
    {
        _themeSelectionUI = Instantiate(_themeSelectionUIPrefab);
        UIRoot.AttachSceneUI(_themeSelectionUI.transform);
    }

    private void CreateThemes()
    {
        var menu = new ThemeSelectionMenu(_themeSelectionUI, _themeCreator, _themeTracker);
        menu.CreateThemes();
    }
}
