using TMPro;
using UnityEngine;

public class EnemyConfigBuilder : SwordsmanConfigBuilder
{
    private readonly EnemyConfig _initial;
    private readonly EnemyProgressionConfig _progression;
    private readonly LevelTracker _levelTracker;

    public EnemyConfigBuilder(EnemyConfig initial, EnemyProgressionConfig progression, LevelTracker levelTracker) : 
        base(initial.SwordsmanConfig, progression.SwordsmanProgressionConfig, levelTracker.Progress)
    {
        _initial = initial;
        _progression = progression;
        _levelTracker = levelTracker;
    }

    private SwordsmanSpritesConfig Sprites => _initial.SwordsmanConfig.SpritesConfig;

    public EnemyConfig Build()
    {
        var swordsman = BuildSwordsman();
        var stateUpdateCooldown = _initial.StateUpdateCooldown * _progression.StateUpdateCooldownOverLevel.Evaluate(_levelTracker.Progress);
        var attackProbability = _initial.AttackProbability * _progression.AttackProbabilityOverLevel.Evaluate(_levelTracker.Progress);
        var parryProbability = _initial.ParryProbability * _progression.ParryProbabilityOverLevel.Evaluate(_levelTracker.Progress);

        var enemy = new EnemyConfig(swordsman, stateUpdateCooldown, attackProbability, parryProbability);
        return enemy;
    }

    protected override SwordsmanSpritesConfig BuildSprites()
    {
        var sprites = Object.Instantiate(_levelTracker.CurrentLevelData.EnemyData.SpritesConfig);
        return sprites;
    }
}
