using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgressionConfig", menuName = "Configs/Progression/Player")]
public class PlayerProgressionConfig : ScriptableObject
{
    [field: SerializeField] public SwordsmanProgressionConfig SwordsmanProgressionConfig { get; private set; }
}
