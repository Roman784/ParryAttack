using Zenject;

public class LevelCreator
{
    private ThemeCreator _themeCreator;
    private LevelTracker _levelTracker;

    private ArenaPositions _arenaPositions;

    [Inject]
    private void Construct(ThemeCreator themeCreator, LevelTracker levelTracker)
    {
        _themeCreator = themeCreator;
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
        return _themeCreator.CreateCurrent();
    }

    private ArenaPositions CreateArena(ThemeData theme)
    {
        int width = _levelTracker.CurrentLevelData.ArenaWidth;

        ArenaCreator creator = new ArenaCreator(width, theme);
        return creator.Create();
    }
}
