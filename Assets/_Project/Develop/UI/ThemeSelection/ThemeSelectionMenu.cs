using System.Collections.Generic;

public class ThemeSelectionMenu
{
    private ThemeSelectionUI _ui;
    private ThemeCreator _creator;
    private ThemeTracker _tracker;
    private SceneLoader _sceneLoader;
    private Storage _storage;
    private AudioPlayer _audioPlayer;
    private SDK _SDK;

    private ArenaCreator _arenaCreator;

    private List<Theme> _themes = new();
    private int _currentThemeIndex;

    public ThemeSelectionMenu (ThemeSelectionUI ui, ThemeCreator creator, ThemeTracker tracker, SceneLoader sceneLoader, 
                               Storage storage, AudioPlayer audioPlayer, SDK SDK)
    {
        _ui = ui;
        _creator = creator;
        _tracker = tracker;
        _sceneLoader = sceneLoader;
        _storage = storage;
        _audioPlayer = audioPlayer;
        _SDK = SDK;

        _ui.OnPreviousThemeButtonCLick.AddListener(() => SwitchTheme(-1));
        _ui.OnNextThemeButtonClick.AddListener(() => SwitchTheme(1));
        _ui.OnSelectThemeButtonClick.AddListener(SelectCurrentTheme);
        _ui.OnThemeUnlockConfirm.AddListener(UnlockTheme);

        _ui.OnPreviousThemeButtonCLick.AddListener(_audioPlayer.UISounds.PlayButtonClick);
        _ui.OnNextThemeButtonClick.AddListener(_audioPlayer.UISounds.PlayButtonClick);
        _ui.OnSelectThemeButtonClick.AddListener(_audioPlayer.UISounds.PlayButtonClick);
        _ui.OnThemeUnlockConfirm.AddListener(_audioPlayer.UISounds.PlayButtonClick);
    }

    private Theme CurrentTheme => _themes[_currentThemeIndex];

    public void CreateThemes()
    {
        _themes = _creator.CreateAll();
        
        DisableThemes();
        EnableCurrentTheme();
    }

    public void SwitchTheme(int step)
    {
        CurrentTheme.Disable();

        _currentThemeIndex += step;
        ClampCurrentThemeIndex();

        EnableTheme(CurrentTheme);
    }

    public void SelectCurrentTheme()
    {
        _tracker.SetCurrentTheme(CurrentTheme.Data.Key);
        _storage.SetCurrentTheme(CurrentTheme.Data.Key);

        _sceneLoader.LoadGameplay();
    }

    public void UnlockTheme()
    {
        _SDK.ShowRewardedVideo((bool res) =>
        {
            if (res)
            {
                _storage.AddUnlockedTheme(CurrentTheme.Data.Key);
                _ui.ShowSelectButton();
            }
            else
            {
                _ui.ShowUnlockButton();
            }
        });
    }

    private void DisableThemes()
    {
        foreach (var theme in _themes)
            theme.Disable();
    }

    private void EnableCurrentTheme()
    {
        int key = _tracker.CurrentTheme.Key;

        for (int i = 0; i < _themes.Count; i++)
        {
            if (_themes[i].Data.Key == key)
            {
                EnableTheme(_themes[i]);
                _currentThemeIndex = i;

                return;
            }
        }
    }

    private void EnableTheme(Theme theme)
    {
        theme.Enable();
        CreateArena(theme.Data);

        if (IsUnlocked(theme.Data.Key))
            _ui.ShowSelectButton();
        else
            _ui.ShowUnlockButton();
    }

    private void CreateArena(ThemeData data)
    {
        if (_arenaCreator != null)
            _arenaCreator.Destroy();

        _arenaCreator = new ArenaCreator(4, data);
        _arenaCreator.Create();
    }

    private void ClampCurrentThemeIndex()
    {
        if (_currentThemeIndex >= _themes.Count) _currentThemeIndex = 0;
        if (_currentThemeIndex < 0) _currentThemeIndex = _themes.Count - 1;
    }

    private bool IsUnlocked(int key)
    {
        return _storage.GameData.UnlockedThemes.Contains(key);
    }
}
