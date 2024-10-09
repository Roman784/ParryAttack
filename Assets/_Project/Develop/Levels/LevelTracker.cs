using Zenject;

public class LevelTracker
{
    private LevelListConfig _levelListConfig;

    private int _lastNumber;
    private int _currentNumber;

    [Inject]
    private void Construct(LevelListConfig levelListConfig)
    {
        _levelListConfig = levelListConfig;

        _lastNumber = _levelListConfig.Levels.Count;
    }

    public float Progress => _currentNumber / _lastNumber;
    public LevelData CurrentLevelData => _levelListConfig.Levels[_currentNumber - 1];

    public void SetCurrentLevelNumber(int newNumber)
    {
        _currentNumber = newNumber;
    }
}
