using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanConfig", menuName = "Configs/Swordsman/Main")]
public class SwordsmanConfig : ScriptableObject
{
    [field: SerializeField] public SwordsmanAttributesConfig AttributesConfig;
    [field: SerializeField] public SwordsmanSpritesConfig SpritesConfig;
}
