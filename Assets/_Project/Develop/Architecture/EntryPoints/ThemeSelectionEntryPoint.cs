using System.Collections;
using Zenject;

public class ThemeSelectionEntryPoint : EntryPoint
{
    private ThemeSelectionUI _themeSelectionUI;
    private ThemeSelectionUI _themeSelectionUIPrefab;

    private ThemeCreator _themeCreator;
    private ThemeTracker _themeTracker;

    private SceneLoader _sceneLoader;
    private Storage _storage;

    [Inject]
    private void Construct(ThemeSelectionUI themeSelectionUIPrefab, ThemeCreator themeCreator, 
                           ThemeTracker themeTracker, SceneLoader sceneLoader, Storage storage)
    {
        _themeSelectionUIPrefab = themeSelectionUIPrefab;
        _themeCreator = themeCreator;
        _themeTracker = themeTracker;
        _sceneLoader = sceneLoader;
        _storage = storage;
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
        var menu = new ThemeSelectionMenu(_themeSelectionUI, _themeCreator, _themeTracker, _sceneLoader, _storage);
        menu.CreateThemes();
    }
}
