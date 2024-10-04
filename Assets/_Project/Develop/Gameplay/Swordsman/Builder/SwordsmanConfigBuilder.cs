using UnityEngine;
using Zenject;

public class SwordsmanConfigBuilder : MonoBehaviour
{
    private InitialSwordsmenConfig _initialConfig;

    private PlayerConfig InitialPlayerConfig => _initialConfig.PlayerConfig;
    private EnemyConfig InitialEnemyConfig => _initialConfig.EnemyConfig;
    private SwordsmanConfig InitialSwordsmanConfig => _initialConfig.SwordsmanConfig;
    private SwordsmanFeaturesConfig InitialFeaturesConfig => InitialSwordsmanConfig.FeaturesConfig;
    private SwordsmanAnimationConfig InitialAnimationConfig => InitialSwordsmanConfig.AnimationConfig;

    private int _maxLevel = 4;
    private int _currentLevel = 4;
    private float LevelProgress => _currentLevel / _maxLevel;

    [Inject]
    private void Construct(InitialSwordsmenConfig initialConfig)
    {
        Debug.Log("inject");
        _initialConfig = initialConfig;
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
        float stateUpdateCooldown = InitialEnemyConfig.StateUpdateCooldown;
        float attackProbability = InitialEnemyConfig.AttackProbability;
        float parryProbability = InitialEnemyConfig.ParryProbability;

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
        float preattackDuration = InitialFeaturesConfig.PreattackDuration;
        float attackDuration = InitialFeaturesConfig.AttackDuration;

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
