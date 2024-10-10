using UnityEngine;

public abstract class SwordsmanConfigBuilder
{
    private readonly SwordsmanConfig _initial;
    private readonly SwordsmanProgressionConfig _progression;

    private readonly float _levelProgress;

    public SwordsmanConfigBuilder(SwordsmanConfig initialConfig, SwordsmanProgressionConfig progressionConfig, float levelProgress)
    { 
        _initial = initialConfig;
        _progression = progressionConfig;
        _levelProgress = levelProgress;
    }

    private SwordsmanFeaturesConfig Features => _initial.FeaturesConfig;
    private SwordsmanAnimationConfig Animation => _initial.AnimationConfig;

    protected SwordsmanConfig BuildSwordsman()
    {
        var features = BuildFeatures();
        var animation = BuildAnimation();
        var sprites = BuildSprites();

        var swordsman = new SwordsmanConfig(features, animation, sprites);
        return swordsman;
    }

    protected SwordsmanFeaturesConfig BuildFeatures()
    {
        var healthAmount = Mathf.RoundToInt(Features.HealthAmount * _progression.HealthAmountOverLevel.Evaluate(_levelProgress));
        var preattackDuration = Features.PreattackDuration * _progression.PreattackDurationOverLevel.Evaluate(_levelProgress);
        var attackDuration = Features.AttackDuration * _progression.AttackDurationOverLevel.Evaluate(_levelProgress);

        var features = new SwordsmanFeaturesConfig(healthAmount, preattackDuration, attackDuration);
        return features;
    }

    protected SwordsmanAnimationConfig BuildAnimation()
    {
        var damageColor = Animation.DamageColor;
        var damageTickCount = Animation.DamageTickCount;
        var damageTickRate = Animation.DamageTickRate;

        var animation = new SwordsmanAnimationConfig(damageColor, damageTickCount, damageTickRate);
        return animation;
    }

    protected abstract SwordsmanSpritesConfig BuildSprites();
}
