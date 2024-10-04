using UnityEngine;
using Zenject;

public class SwordsmanConfigBuilder
{
    private InitialSwordsmenConfig _initialConfig;
    private DifficultyAdjuster _difficultyAdjuster;

    private PlayerConfig InitialPlayerConfig => _initialConfig.PlayerConfig;
    private EnemyConfig InitialEnemyConfig => _initialConfig.EnemyConfig;
    private SwordsmanConfig InitialSwordsmanConfig => _initialConfig.SwordsmanConfig;
    private SwordsmanFeaturesConfig InitialFeaturesConfig => InitialSwordsmanConfig.FeaturesConfig;
    private SwordsmanAnimationConfig InitialAnimationConfig => InitialSwordsmanConfig.AnimationConfig;

    [Inject]
    private void Construct(InitialSwordsmenConfig initialConfig, DifficultyAdjuster difficultyAdjuster)
    {
        _initialConfig = initialConfig;
        _difficultyAdjuster = difficultyAdjuster;
    }

    public PlayerConfig BuildPlayer()
    {
        SwordsmanConfig swordsmanConfig = BuildSwordsman();
        PlayerConfig playerConfig = new(swordsmanConfig);

        return playerConfig;
    }

    public EnemyConfig BuildEnemy()
    {
        SwordsmanConfig swordsmanConfig = BuildSwordsman();
        float stateUpdateCooldown = _difficultyAdjuster.Resolve(FieldsChangedByDifficulty.StateUpdateCooldown, InitialEnemyConfig.StateUpdateCooldown);
        float attackProbability = _difficultyAdjuster.Resolve(FieldsChangedByDifficulty.AttackProbability, InitialEnemyConfig.AttackProbability);
        float parryProbability = _difficultyAdjuster.Resolve(FieldsChangedByDifficulty.ParryProbability, InitialEnemyConfig.ParryProbability);

        EnemyConfig enemyConfig = new(swordsmanConfig, stateUpdateCooldown, attackProbability, parryProbability);

        return enemyConfig;
    }

    private SwordsmanConfig BuildSwordsman()
    {
        SwordsmanFeaturesConfig featuresConfig = BuildFeatures();
        SwordsmanAnimationConfig animationConfig = BuildAnimation();

        SwordsmanConfig swordsmanConfig = new(featuresConfig, animationConfig);

        return swordsmanConfig;
    }

    private SwordsmanFeaturesConfig BuildFeatures()
    {
        int heartsCount = InitialFeaturesConfig.HeartsCount;
        float preattackDuration = _difficultyAdjuster.Resolve(FieldsChangedByDifficulty.PreattackDuration, InitialFeaturesConfig.PreattackDuration);
        float attackDuration = _difficultyAdjuster.Resolve(FieldsChangedByDifficulty.AttackDuration, InitialFeaturesConfig.AttackDuration);

        SwordsmanFeaturesConfig featuresConfig = new(heartsCount, preattackDuration, attackDuration);

        return featuresConfig;
    }

    private SwordsmanAnimationConfig BuildAnimation()
    {
        SwordsmanSpritesConfig spritesConfig = BuildSprites();
        Color damageColor = InitialAnimationConfig.DamageColor;
        int damageTickCount = InitialAnimationConfig.DamageTickCount;
        float damageTickRate = InitialAnimationConfig.DamageTickRate;

        SwordsmanAnimationConfig animationConfig = new(spritesConfig, damageColor, damageTickCount, damageTickRate);

        return animationConfig;
    }

    private SwordsmanSpritesConfig BuildSprites()
    {
        Sprite idle = InitialAnimationConfig.SpritesConfig.Idle;
        Sprite preattack = InitialAnimationConfig.SpritesConfig.Preattack;
        Sprite attack = InitialAnimationConfig.SpritesConfig.Attack;
        Sprite parry = InitialAnimationConfig.SpritesConfig.Parry;

        SwordsmanSpritesConfig spritesConfig = new(idle, preattack, attack, parry);

        return spritesConfig;
    }
}
