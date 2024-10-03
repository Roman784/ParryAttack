using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanConfig", menuName = "Configs/Swordsman/Swordsman")]
public class SwordsmanConfig : ScriptableObject
{
    [field: SerializeField] public SwordsmanFeaturesConfig FeaturesConfig { get; private set; }
    [field: SerializeField] public SwordsmanAnimationConfig AnimationConfig { get; private set; }

    public SwordsmanConfig(SwordsmanFeaturesConfig featuresConfig, SwordsmanAnimationConfig animationConfig)
    {
        FeaturesConfig = featuresConfig;
        AnimationConfig = animationConfig;
    }
}
