using UnityEngine;

[CreateAssetMenu(fileName = "SwordsmanConfig", menuName = "Configs/Swordsman/SwordsmanConfig")]
public class SwordsmanConfig : ScriptableObject
{
    [field: SerializeField] public Sprite Idle { get; private set; }
    [field: SerializeField] public Sprite Preattack { get; private set; }
    [field: SerializeField] public Sprite Attack { get; private set; }
    [field: SerializeField] public Sprite Parry { get; private set; }
}
