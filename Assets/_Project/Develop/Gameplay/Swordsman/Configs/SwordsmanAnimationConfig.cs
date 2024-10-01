using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanAnimationConfig", menuName = "Configs/Swordsman/Animation")]
public class SwordsmanAnimationConfig : ScriptableObject
{
    [field: SerializeField] public SwordsmanSpritesConfig SpritesConfig { get; private set; }

    [field: Space, SerializeField] public Color DamageColor { get; private set; }
    [field: SerializeField] public int DamageTickCount { get; private set; }
    [field: SerializeField] public float DamageTickRate {  get; private set; }
}
