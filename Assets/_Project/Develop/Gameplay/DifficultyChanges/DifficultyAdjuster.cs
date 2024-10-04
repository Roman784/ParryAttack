using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DifficultyAdjuster
{
    private int _maxLevel = 4;
    private int _currentLevel = 4;
    private float LevelProgress => _currentLevel / _maxLevel;

    private Dictionary<FieldsChangedByDifficulty, AnimationCurve> _changesByCurveMap;
    private DifficultyChangesConfig _changesConfig;

    [Inject]
    private void Construct(DifficultyChangesConfig changesConfig)
    {
        _changesConfig = changesConfig;

        InitChangesMap();
    }

    private void InitChangesMap()
    {
        _changesByCurveMap = new Dictionary<FieldsChangedByDifficulty, AnimationCurve>();

        _changesByCurveMap[FieldsChangedByDifficulty.StateUpdateCooldown] = _changesConfig.StateUpdateCooldown;
        _changesByCurveMap[FieldsChangedByDifficulty.AttackProbability] = _changesConfig.AttackProbability;
        _changesByCurveMap[FieldsChangedByDifficulty.ParryProbability] = _changesConfig.ParryProbability;
        _changesByCurveMap[FieldsChangedByDifficulty.PreattackDuration] = _changesConfig.PreattackDuration;
        _changesByCurveMap[FieldsChangedByDifficulty.AttackDuration] = _changesConfig.AttackDuration;
    }

    public float Resolve(FieldsChangedByDifficulty name, float initialValue)
    {
        return Adjust(initialValue, _changesByCurveMap[name]);
    }

    private float Adjust(float value, AnimationCurve curve)
    {
        return value * curve.Evaluate(LevelProgress);
    }
}
