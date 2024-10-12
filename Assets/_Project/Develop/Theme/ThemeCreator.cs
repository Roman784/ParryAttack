using System.Linq;
using UnityEngine;
using Zenject;

public class ThemeCreator
{
    private ThemeTracker _tracker;

    [Inject]
    private void Construct(ThemeTracker tracker)
    {
        _tracker = tracker;
    }

    public ThemeData Create()
    {
        ThemeData theme = _tracker.CurrentTheme;

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
}
