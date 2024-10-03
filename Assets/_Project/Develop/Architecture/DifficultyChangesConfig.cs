using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyChangesConfig", menuName = "Configs/DifficultyChanges")]
public class DifficultyChangesConfig : ScriptableObject
{
    [field: Header("Enemy")]
    [field: SerializeField] public AnimationCurve HeartsCount { get; private set; }
    [field: SerializeField] public AnimationCurve StateUpdateCooldown { get; private set; }
    [field: SerializeField] public AnimationCurve AttackProbability {  get; private set; }
    [field: SerializeField] public AnimationCurve ParryProbability { get; private set; }

    [field: Header("Common")]
    [field: SerializeField] public AnimationCurve PreattackDuration { get; private set; }
    [field: SerializeField] public AnimationCurve AttackDuration { get; private set; }
}
