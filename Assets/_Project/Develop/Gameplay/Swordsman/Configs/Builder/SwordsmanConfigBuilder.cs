using UnityEngine;

public abstract class SwordsmanConfigBuilder
{
    private InitialSwordsmenConfig _initialConfig;

    public SwordsmanConfigBuilder(InitialSwordsmenConfig initialConfig)
    { 
        _initialConfig = initialConfig;
    }

    protected SwordsmanConfig InitialSwordsmanConfig => _initialConfig.SwordsmanConfig;
    protected SwordsmanFeaturesConfig InitialFeaturesConfig => InitialSwordsmanConfig.FeaturesConfig;
    protected SwordsmanAnimationConfig InitialAnimationConfig => InitialSwordsmanConfig.AnimationConfig;

    protected SwordsmanConfig BuildSwordsman()
    {
        SwordsmanFeaturesConfig featuresConfig = BuildFeatures();
        SwordsmanAnimationConfig animationConfig = BuildAnimation();

        SwordsmanConfig swordsmanConfig = new(featuresConfig, animationConfig);

        return swordsmanConfig;
    }

    protected virtual SwordsmanFeaturesConfig BuildFeatures()
    {
        int heartsCount = InitialFeaturesConfig.HeartsCount;
        float preattackDuration = InitialFeaturesConfig.PreattackDuration;
        float attackDuration = InitialFeaturesConfig.AttackDuration;

        SwordsmanFeaturesConfig featuresConfig = new(heartsCount, preattackDuration, attackDuration);

        return featuresConfig;
    }

    protected virtual SwordsmanAnimationConfig BuildAnimation()
    {
        SwordsmanSpritesConfig spritesConfig = BuildSprites();
        Color damageColor = InitialAnimationConfig.DamageColor;
        int damageTickCount = InitialAnimationConfig.DamageTickCount;
        float damageTickRate = InitialAnimationConfig.DamageTickRate;

        SwordsmanAnimationConfig animationConfig = new(spritesConfig, damageColor, damageTickCount, damageTickRate);

        return animationConfig;
    }

    protected virtual SwordsmanSpritesConfig BuildSprites()
    {
        Sprite idle = InitialAnimationConfig.SpritesConfig.Idle;
        Sprite preattack = InitialAnimationConfig.SpritesConfig.Preattack;
        Sprite attack = InitialAnimationConfig.SpritesConfig.Attack;
        Sprite parry = InitialAnimationConfig.SpritesConfig.Parry;

        SwordsmanSpritesConfig spritesConfig = new(idle, preattack, attack, parry);

        return spritesConfig;
    }
}
