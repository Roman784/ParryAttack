using Zenject;

public class LevelCreator
{
    private ThemesConfig _themesCongif;
    private LevelTracker _levelTracker;

    private ArenaPositions _arenaPositions;

    [Inject]
    private void Construct(ThemesConfig themesConfig, LevelTracker levelTracker)
    {
        _themesCongif = themesConfig;
        _levelTracker = levelTracker;
    }

    public ArenaPositions ArenaPositions => _arenaPositions;

    public ArenaPositions Create()
    {
        ThemeData theme = CreateTheme();
        _arenaPositions = CreateArena(theme);

        return _arenaPositions;
    }

    private ThemeData CreateTheme()
    {
        ThemeCreator creator = new ThemeCreator(_themesCongif);
        return creator.Create();
    }

    private ArenaPositions CreateArena(ThemeData theme)
    {
        int width = _levelTracker.CurrentLevelData.ArenaWidth;

        ArenaCreator creator = new ArenaCreator(width, theme);
        return creator.Create();
    }
}
