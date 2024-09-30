using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanConfig", menuName = "Configs/Swordsman/Swordsman")]
public class SwordsmanConfig : ScriptableObject
{
    [field: SerializeField] public SwordsmanAttributesConfig AttributesConfig { get; private set; }
    [field: SerializeField] public SwordsmanAnimationConfig AnimationConfig { get; private set; }
}
