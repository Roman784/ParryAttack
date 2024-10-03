using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/Swordsman/Enemy")]
public class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public SwordsmanConfig SwordsmanConfig {  get; private set; }

    [field: Space]
    [field: SerializeField] public float StateUpdateCooldown { get; private set; }
    [field: SerializeField, Range(0f, 1f)] public float AttackProbability { get; private set; }
    [field: SerializeField, Range(0f, 1f)] public float ParryProbability { get; private set; }

    public EnemyConfig(SwordsmanConfig swordsmanConfig, float stateUpdateCooldown, float attackProbability, float parryProbability)
    {
        SwordsmanConfig = swordsmanConfig;
        StateUpdateCooldown = stateUpdateCooldown;
        AttackProbability = attackProbability;
        ParryProbability = parryProbability;
    }
}
