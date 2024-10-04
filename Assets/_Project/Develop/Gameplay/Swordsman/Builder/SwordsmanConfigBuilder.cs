using UnityEngine;
using Zenject;

public class SwordsmanConfigBuilder
{
    private InitialSwordsmenConfig _initialConfig;
    private DifficultyChangesConfig _difficultyChangesConfig;

    private DifficultyAdjuster _difficultyAdjuster;

    private PlayerConfig InitialPlayerConfig => _initialConfig.PlayerConfig;
    private EnemyConfig InitialEnemyConfig => _initialConfig.EnemyConfig;
    private SwordsmanConfig InitialSwordsmanConfig => _initialConfig.SwordsmanConfig;
    private SwordsmanFeaturesConfig InitialFeaturesConfig => InitialSwordsmanConfig.FeaturesConfig;
    private SwordsmanAnimationConfig InitialAnimationConfig => InitialSwordsmanConfig.AnimationConfig;

    [Inject]
    private void Construct(InitialSwordsmenConfig initialConfig, DifficultyChangesConfig difficultyChangesConfig)
    {
        _initialConfig = initialConfig;
        _difficultyChangesConfig = difficultyChangesConfig;

        _difficultyAdjuster = new DifficultyAdjuster();
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
        float stateUpdateCooldown = _difficultyAdjuster.Adjust(InitialEnemyConfig.StateUpdateCooldown, _difficultyChangesConfig.StateUpdateCooldown);
        float attackProbability = _difficultyAdjuster.Adjust(InitialEnemyConfig.AttackProbability, _difficultyChangesConfig.AttackProbability);
        float parryProbability = _difficultyAdjuster.Adjust(InitialEnemyConfig.ParryProbability, _difficultyChangesConfig.ParryProbability);

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
        float preattackDuration = _difficultyAdjuster.Adjust(InitialFeaturesConfig.PreattackDuration, _difficultyChangesConfig.PreattackDuration);
        float attackDuration = _difficultyAdjuster.Adjust(InitialFeaturesConfig.AttackDuration, _difficultyChangesConfig.AttackDuration);

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
