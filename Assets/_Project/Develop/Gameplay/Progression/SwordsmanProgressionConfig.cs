using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanProgressionConfig", menuName = "Configs/Progression/Swordsman")]
public class SwordsmanProgressionConfig : ScriptableObject
{
    [field: SerializeField] public AnimationCurve HealthAmountOverLevel { get; private set; }
    [field: SerializeField] public AnimationCurve PreattackDurationOverLevel { get; private set; }
    [field: SerializeField] public AnimationCurve AttackDurationOverLevel { get; private set; }
}
