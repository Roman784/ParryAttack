using System.Linq;
using UnityEngine;
using Zenject;

public class ThemeCreator
{
    private ThemesConfig _config;

    [Inject]
    private void Construct(ThemesConfig config)
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

    private void DestroyCurrentTheme()
    {

    }

    private ThemeData GetRandomTheme()
    {
        int i = Random.Range(0, _config.Themes.Count());
        return _config.Themes[i];
    }
}
