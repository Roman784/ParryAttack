using System;
using UnityEngine;

[Serializable]
public class LevelData
{
    public int Number {  get; private set; }
    [field: SerializeField] public int ArenaWidth { get; private set; }
    [field: SerializeField] public EnemyData EnemyData { get; private set; }

    public void SetNumber(int number)
    {
        Number = number;
    }
}
