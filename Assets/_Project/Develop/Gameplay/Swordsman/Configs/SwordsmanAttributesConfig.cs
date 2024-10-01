using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanAttributesConfig", menuName = "Configs/Swordsman/Attributes")]
public class SwordsmanAttributesConfig : ScriptableObject
{
    [field: SerializeField] public int HeartsCount { get; private set; }
    [field: SerializeField] public float PreattackDuration { get; private set; }
    [field: SerializeField] public float AttackDuration { get; private set; }
}
