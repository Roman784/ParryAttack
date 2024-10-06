using System.Linq;
using UnityEngine;

public class ThemeCreator
{
    private ThemesConfig _config;

    public ThemeCreator(ThemesConfig config)
    {
        _config = config;
    }

    public ThemeData Create()
    {
        ThemeData theme = GetRandomTheme();

        CreateBackground(theme);
        SetSkyColor(theme);

        return theme;
    }

    private void CreateBackground(ThemeData theme)
    {
        Vector2 position = Vector2.zero;
        Object.Instantiate(theme.Background, position, Quaternion.identity);
    }

    private void SetSkyColor(ThemeData theme)
    {
        Camera.main.backgroundColor = theme.SkyColor;
    }

    private ThemeData GetRandomTheme()
    {
        int i = Random.Range(0, _config.Themes.Count());
        return _config.Themes[i];
    }
}
