public class EnemyConfigBuilder : SwordsmanConfigBuilder
{
    private EnemyConfig _initialEnemyConfig;
    private DifficultyAdjuster _difficultyAdjuster;

    public EnemyConfigBuilder(InitialSwordsmenConfig initialConfig, DifficultyAdjuster difficultyAdjuster) : base(initialConfig)
    {
        _initialEnemyConfig = initialConfig.EnemyConfig;
        _difficultyAdjuster = difficultyAdjuster;
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
}
