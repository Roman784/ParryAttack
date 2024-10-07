using UnityEngine;

public class EnemyConfigBuilder : SwordsmanConfigBuilder
{
    private EnemyConfig _initialEnemyConfig;
    private DifficultyAdjuster _difficultyAdjuster;
    private LevelData _currentLevelData;

    public EnemyConfigBuilder(InitialSwordsmenConfig initialConfig, DifficultyAdjuster difficultyAdjuster, LevelData currentLevelData) : base(initialConfig)
    {
        _initialEnemyConfig = initialConfig.EnemyConfig;
        _difficultyAdjuster = difficultyAdjuster;
        _currentLevelData = currentLevelData;
    }

    public EnemyConfig Build()
    {
        SwordsmanConfig swordsmanConfig = BuildSwordsman();
        float stateUpdateCooldown = _difficultyAdjuster.Resolve(FieldsChangedByDifficulty.StateUpdateCooldown, _initialEnemyConfig.StateUpdateCooldown);
        float attackProbability = _difficultyAdjuster.Resolve(FieldsChangedByDifficulty.AttackProbability, _initialEnemyConfig.AttackProbability);
        float parryProbability = _difficultyAdjuster.Resolve(FieldsChangedByDifficulty.ParryProbability, _initialEnemyConfig.ParryProbability);

        EnemyConfig enemyConfig = new(swordsmanConfig, stateUpdateCooldown, attackProbability, parryProbability);

        return enemyConfig;
    }

    protected override SwordsmanFeaturesConfig BuildFeatures()
    {
        int heartsCount = InitialFeaturesConfig.HeartsCount;
        float preattackDuration = _difficultyAdjuster.Resolve(FieldsChangedByDifficulty.PreattackDuration, InitialFeaturesConfig.PreattackDuration);
        float attackDuration = _difficultyAdjuster.Resolve(FieldsChangedByDifficulty.AttackDuration, InitialFeaturesConfig.AttackDuration);

        SwordsmanFeaturesConfig featuresConfig = new(heartsCount, preattackDuration, attackDuration);

        return featuresConfig;
    }

    protected override SwordsmanSpritesConfig BuildSprites()
    {
        Sprite idle = _currentLevelData.EnemySprites.Idle;
        Sprite preattack = _currentLevelData.EnemySprites.Preattack;
        Sprite attack = _currentLevelData.EnemySprites.Attack;
        Sprite parry = _currentLevelData.EnemySprites.Parry;
        Sprite defeat = _currentLevelData.EnemySprites.Defeat;

        SwordsmanSpritesConfig spritesConfig = new(idle, preattack, attack, parry, defeat);

        return spritesConfig;
    }
}
