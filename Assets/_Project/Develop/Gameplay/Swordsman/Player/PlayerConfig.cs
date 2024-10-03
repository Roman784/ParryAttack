using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Swordsman/Player")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public SwordsmanConfig SwordsmanConfig { get; private set; }

    public PlayerConfig(SwordsmanConfig swordsmanConfig)
    {
        SwordsmanConfig = swordsmanConfig;
    }
}
