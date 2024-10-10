using UnityEngine;

[CreateAssetMenu(fileName = "EnemyProgressionConfig", menuName = "Configs/Progression/Enemy")]
public class EnemyProgressionConfig : ScriptableObject
{
    [field: SerializeField] public SwordsmanProgressionConfig SwordsmanProgressionConfig { get; private set; }

    [field: Space]
    [field: SerializeField] public AnimationCurve StateUpdateCooldownOverLevel { get; private set; }
    [field: SerializeField] public AnimationCurve AttackProbabilityOverLevel { get; private set; }
    [field: SerializeField] public AnimationCurve ParryProbabilityOverLevel { get; private set; }
}
