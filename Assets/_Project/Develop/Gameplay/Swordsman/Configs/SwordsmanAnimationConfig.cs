using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanSpritesConfig", menuName = "Configs/Swordsman/Sprites")]
public class SwordsmanAnimationConfig : ScriptableObject
{
    [field: SerializeField] public Sprite Idle { get; private set; }
    [field: SerializeField] public Sprite Preattack { get; private set; }
    [field: SerializeField] public Sprite Attack { get; private set; }
    [field: SerializeField] public Sprite Parry { get; private set; }
}
