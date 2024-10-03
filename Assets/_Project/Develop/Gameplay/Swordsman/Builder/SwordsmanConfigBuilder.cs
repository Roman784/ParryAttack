using UnityEngine;

public class SwordsmanConfigBuilder : MonoBehaviour
{
    [SerializeField] private DifficultyChangesConfig _difficultyChangesConfig;
    [SerializeField] private EnemyConfig _defaultEnemyConfig;
    [SerializeField] private SwordsmanConfig _defaultSwordsmanConfig;

    private int _maxLevel = 4;
    private int _currentLevel = 4;
    private float LevelProgress => _currentLevel / _maxLevel;

    public PlayerConfig BuildPlayer()
    {
        SwordsmanConfig swordsmanConfig = BuildSwordsman();
        PlayerConfig playerConfig = new(swordsmanConfig);

        return playerConfig;
    }

    public EnemyConfig BuildEnemy()
    {
        SwordsmanConfig swordsmanConfig = BuildSwordsman();
        float stateUpdateCooldown = _defaultEnemyConfig.StateUpdateCooldown;
        float attackProbability = _defaultEnemyConfig.AttackProbability;
        float parryProbability = _defaultEnemyConfig.ParryProbability;

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
        int heartsCount = 2;
        float preattackDuration = 0.5f;
        float attackDuration = 0.5f;

        SwordsmanFeaturesConfig featuresConfig = new(heartsCount, preattackDuration, attackDuration);

        return featuresConfig;
    }

    private SwordsmanAnimationConfig BuildAnimation()
    {
        SwordsmanSpritesConfig spritesConfig = BuildSprites();
        Color damageColor = _defaultSwordsmanConfig.AnimationConfig.DamageColor;
        int damageTickCount = _defaultSwordsmanConfig.AnimationConfig.DamageTickCount;
        float damageTickRate = _defaultSwordsmanConfig.AnimationConfig.DamageTickRate;

        SwordsmanAnimationConfig animationConfig = new(spritesConfig, damageColor, damageTickCount, damageTickRate);

        return animationConfig;
    }

    private SwordsmanSpritesConfig BuildSprites()
    {
        Sprite idle = _defaultSwordsmanConfig.AnimationConfig.SpritesConfig.Idle;
        Sprite preattack = _defaultSwordsmanConfig.AnimationConfig.SpritesConfig.Preattack;
        Sprite attack = _defaultSwordsmanConfig.AnimationConfig.SpritesConfig.Attack;
        Sprite parry = _defaultSwordsmanConfig.AnimationConfig.SpritesConfig.Parry;

        SwordsmanSpritesConfig spritesConfig = new(idle, preattack, attack, parry);

        return spritesConfig;
    }
}
