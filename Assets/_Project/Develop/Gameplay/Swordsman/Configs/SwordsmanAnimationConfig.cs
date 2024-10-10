using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanAnimationConfig", menuName = "Configs/Swordsman/Animation")]
public class SwordsmanAnimationConfig : ScriptableObject
{
    [field: SerializeField] public Color DamageColor { get; private set; }
    [field: SerializeField] public int DamageTickCount { get; private set; }
    [field: SerializeField] public float DamageTickRate {  get; private set; }

    public SwordsmanAnimationConfig(Color damageColor, int damageTickCount, float damageTickRate)
    {
        DamageColor = damageColor;
        DamageTickCount = damageTickCount;
        DamageTickRate = damageTickRate;
    }
}
