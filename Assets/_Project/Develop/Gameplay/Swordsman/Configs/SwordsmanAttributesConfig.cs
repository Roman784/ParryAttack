using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanAttributesConfig", menuName = "Configs/Swordsman/Attributes")]
public class SwordsmanAttributesConfig : ScriptableObject
{
    [field: SerializeField] public float PreattackDuration;
    [field: SerializeField] public float AttackDuration;
}
