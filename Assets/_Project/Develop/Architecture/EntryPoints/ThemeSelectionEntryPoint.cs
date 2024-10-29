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
    private AudioPlayer _audioPlayer;
    private SDK _SDK;
    private DiContainer _diContainer;

    [Inject]
    private void Construct(DiContainer diContainer, ThemeSelectionUI themeSelectionUIPrefab, ThemeCreator themeCreator, 
                           ThemeTracker themeTracker, SceneLoader sceneLoader, AudioPlayer audioPlayer,
                           Storage storage, SDK SDK)
    {
        _diContainer = diContainer;
        _themeSelectionUIPrefab = themeSelectionUIPrefab;
        _themeCreator = themeCreator;
        _themeTracker = themeTracker;
        _sceneLoader = sceneLoader;
        _storage = storage;
        _audioPlayer = audioPlayer;
        _SDK = SDK;
    }

    public override IEnumerator Run()
    {
        yield return null;

        CreateUI();
        CreateThemes();
    }

    private void CreateUI()
    {
        _themeSelectionUI = _diContainer.InstantiatePrefab(_themeSelectionUIPrefab).GetComponent<ThemeSelectionUI>();
        UIRoot.AttachSceneUI(_themeSelectionUI.transform);
    }

    private void CreateThemes()
    {
        var menu = new ThemeSelectionMenu(_themeSelectionUI, _themeCreator, _themeTracker, 
                                          _sceneLoader, _storage, _audioPlayer, _SDK);
        menu.CreateThemes();
    }
}
