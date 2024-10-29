using System.Collections;
using Zenject;

public class LevelListEntryPoint : EntryPoint
{
    private LevelListUI _levelListUI;
    private LevelListUI _levelListUIPrefab;

    private LevelListConfig _levelListConfig;
    
    private SceneLoader _sceneLoader;
    private LevelTracker _levelTracker;
    private ThemeCreator _themeCreator;
    private Storage _storage;
    private AudioPlayer _audioPlayer;
    private Translator _translator;

    [Inject]
    private void Construct(LevelListUI levelListUIPrefab, LevelListConfig levelListConfig,
                           SceneLoader sceneLoader, LevelTracker levelTracker, ThemeCreator themeCreator,
                           Storage storage, AudioPlayer audioPlayer, Translator translator)
    {
        _levelListUIPrefab = levelListUIPrefab;
        _levelListConfig = levelListConfig;
        _sceneLoader = sceneLoader;
        _levelTracker = levelTracker;
        _themeCreator = themeCreator;
        _storage = storage;
        _audioPlayer = audioPlayer;
        _translator = translator;
    }

    public override IEnumerator Run()
    {
        yield return null;

        CreateUI();
        CreateLevelButtons();
        CreateTheme();
    }

    private void CreateUI()
    {
        _levelListUI = Instantiate(_levelListUIPrefab);
        UIRoot.AttachSceneUI(_levelListUI.transform);
    }

    private void CreateLevelButtons()
    {
        var menu = new LevelListMenu(_levelListUI, _levelListConfig, _sceneLoader, 
                                     _levelTracker, _storage, _audioPlayer, _translator);
        menu.CreateButtons();
    }

    private void CreateTheme()
    {
        _themeCreator.CreateCurrent();
    }
}
