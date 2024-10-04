using UnityEngine;

public class DifficultyAdjuster
{
    private int _maxLevel = 4;
    private int _currentLevel = 1;
    private float LevelProgress => _currentLevel / _maxLevel;

    public float Adjust(float value, AnimationCurve curve)
    {
        return value * curve.Evaluate(LevelProgress);
    }
}
