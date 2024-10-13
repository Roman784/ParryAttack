using System;
using System.Linq;
using Zenject;

public class ThemeTracker
{
    private ThemesConfig _config;

    private int _currentThemeKey = 1;

    [Inject]
    private void Construct(ThemesConfig config)
    {
        _config = config;
    }

    public ThemeData CurrentTheme => _config.Themes.FirstOrDefault(data => data.Key == _currentThemeKey);

    public void SetCurrentTheme(int key)
    {
        if (!IsValidKey(key))
            throw new ArgumentException($"Theme key {key} does not exist");

        _currentThemeKey = key;
    }

    private bool IsValidKey(int key)
    {
        foreach(var theme in _config.Themes)
        {
            if (theme.Key == key)
                return true;
        }

        return false;
    }
}
