using UnityEngine;

[CreateAssetMenu(fileName = "InitialSwordsmenConfig", menuName = "Configs/Swordsman/Initial")]
public class InitialSwordsmenConfig : ScriptableObject
{
    [field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }
    [field: SerializeField] public EnemyConfig EnemyConfig { get; private set; }
    [field: SerializeField] public SwordsmanConfig SwordsmanConfig { get; private set; }
}
