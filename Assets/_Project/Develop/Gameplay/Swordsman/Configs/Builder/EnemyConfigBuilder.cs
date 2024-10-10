using TMPro;
using UnityEngine;

public class EnemyConfigBuilder : SwordsmanConfigBuilder
{
    private readonly EnemyConfig _initial;
    private readonly EnemyProgressionConfig _progression;

    private readonly float _levelProgress;

    public EnemyConfigBuilder(EnemyConfig initial, EnemyProgressionConfig progression, float levelProgress) : 
        base(initial.SwordsmanConfig, progression.SwordsmanProgressionConfig, levelProgress)
    {
        _initial = initial;
        _progression = progression;
        _levelProgress = levelProgress;
    }

    private SwordsmanSpritesConfig Sprites => _initial.SwordsmanConfig.SpritesConfig;

    public EnemyConfig Build()
    {
        var swordsman = BuildSwordsman();
        var stateUpdateCooldown = _initial.StateUpdateCooldown * _progression.StateUpdateCooldownOverLevel.Evaluate(_levelProgress);
        var attackProbability = _initial.AttackProbability * _progression.AttackProbabilityOverLevel.Evaluate(_levelProgress);
        var parryProbability = _initial.ParryProbability * _progression.ParryProbabilityOverLevel.Evaluate(_levelProgress);

        var enemy = new EnemyConfig(swordsman, stateUpdateCooldown, attackProbability, parryProbability);
        return enemy;
    }

    protected override SwordsmanSpritesConfig BuildSprites()
    {
        var idle = Sprites.Idle;
        var preattack = Sprites.Preattack;
        var attack = Sprites.Attack;
        var parry = Sprites.Parry;
        var defeat = Sprites.Defeat;
        var profile = Sprites.Profile;

        var sprites = new SwordsmanSpritesConfig(idle, preattack, attack, parry, defeat, profile);
        return sprites;
    }
}
