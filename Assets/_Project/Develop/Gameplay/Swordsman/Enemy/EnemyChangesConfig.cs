using UnityEngine;

[CreateAssetMenu(fileName = "EnemyChangesConfig", menuName = "Configs/Swordsman/Enemy/Changes")]
public class EnemyChangesConfig : ScriptableObject
{
    [field: SerializeField] public AnimationCurve StateUpdateCooldownOverLevel { get; private set; }
    [field: SerializeField] public AnimationCurve AttackProbabilityOverLevel { get; private set; }
    [field: SerializeField] public AnimationCurve ParryProbabilityOverLevel { get; private set; }

    [field: Space]
    [field: SerializeField] public AnimationCurve HealthAmountOverLevel { get; private set; }
    [field: SerializeField] public AnimationCurve PreattackDurationOverLevel { get; private set; }
    [field: SerializeField] public AnimationCurve AttackDurationOverLevel { get; private set; }
}
