using Zenject;

public class LevelTracker
{
    private LevelListConfig _levelListConfig;

    private int _currentNumber = 1;

    [Inject]
    private void Construct(LevelListConfig levelListConfig)
    {
        _levelListConfig = levelListConfig;
    }

    public float Progress => (_currentNumber - 1f) / (_levelListConfig.Levels.Count - 1f);
    public LevelData CurrentLevelData => _levelListConfig.Levels[_currentNumber - 1];

    public void SetCurrentLevelNumber(int newNumber)
    {
        _currentNumber = newNumber;
    }
}
