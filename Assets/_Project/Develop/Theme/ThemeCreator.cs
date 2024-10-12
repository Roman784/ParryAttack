using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ThemeCreator
{
    private ThemesConfig _config;
    private ThemeTracker _tracker;

    [Inject]
    private void Construct(ThemesConfig config, ThemeTracker tracker)
    {
        _config = config;
        _tracker = tracker;
    }

    public ThemeData CreateCurrent()
    {
        ThemeData theme = _tracker.CurrentTheme;

        CreatePrefab(theme);
        SetSkyColor(theme);

        return theme;
    }

    public List<Theme> CreateAll()
    {
        List<Theme> prefabs = new List<Theme>();

        foreach (var data in _config.Themes)
        {
            Theme prefab = CreatePrefab(data);
            prefabs.Add(prefab);
        }

        return prefabs;
    }

    private Theme CreatePrefab(ThemeData data)
    {
        Theme prefab = Object.Instantiate(data.Prefab, Vector2.zero, Quaternion.identity);
        prefab.Init(data);

        return prefab;
    }

    private void SetSkyColor(ThemeData theme)
    {
        Camera.main.backgroundColor = theme.SkyColor;
    }
}
