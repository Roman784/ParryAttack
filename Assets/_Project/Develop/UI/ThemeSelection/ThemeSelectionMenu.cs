using System.Collections.Generic;
using TMPro;

public class ThemeSelectionMenu
{
    private ThemeSelectionUI _ui;
    private ThemeCreator _creator;
    private ThemeTracker _tracker;

    private ArenaCreator _arenaCreator;

    private List<Theme> _themes = new();
    private int _currentThemeIndex;

    public ThemeSelectionMenu (ThemeSelectionUI ui, ThemeCreator creator, ThemeTracker tracker)
    {
        _ui = ui;
        _creator = creator;
        _tracker = tracker;
    }

    public void CreateThemes()
    {
        _themes = _creator.CreateAll();
        
        DisableThemes();
        EnableCurrentTheme();
    }

    public void SwitchTHeme(int step)
    {
        
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
    }

    private void CreateArena(ThemeData data)
    {
        if (_arenaCreator != null)
            _arenaCreator.Destroy();

        _arenaCreator = new ArenaCreator(3, data);
        _arenaCreator.Create();
    }
}
