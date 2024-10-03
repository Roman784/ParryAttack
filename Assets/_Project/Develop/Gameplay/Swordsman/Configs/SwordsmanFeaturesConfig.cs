using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanFeaturesConfig", menuName = "Configs/Swordsman/Features")]
public class SwordsmanFeaturesConfig : ScriptableObject
{
    [field: SerializeField] public int HeartsCount { get; private set; }

    [field: Space]
    [field: SerializeField] public float PreattackDuration { get; private set; }
    [field: SerializeField] public float AttackDuration { get; private set; }

    public SwordsmanFeaturesConfig(int heartsCount, float preattackDuration, float attackDuration)
    {
        HeartsCount = heartsCount;
        PreattackDuration = preattackDuration;
        AttackDuration = attackDuration;
    }
}
