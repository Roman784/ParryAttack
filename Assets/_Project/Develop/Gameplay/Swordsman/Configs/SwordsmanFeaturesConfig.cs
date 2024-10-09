using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanFeaturesConfig", menuName = "Configs/Swordsman/Features")]
public class SwordsmanFeaturesConfig : ScriptableObject
{
    [field: SerializeField] public int HealthAmount { get; private set; }

    [field: Space]
    [field: SerializeField] public float PreattackDuration { get; private set; }
    [field: SerializeField] public float AttackDuration { get; private set; }

    public SwordsmanFeaturesConfig(int healthAmount, float preattackDuration, float attackDuration)
    {
        HealthAmount = healthAmount;
        PreattackDuration = preattackDuration;
        AttackDuration = attackDuration;
    }
}
