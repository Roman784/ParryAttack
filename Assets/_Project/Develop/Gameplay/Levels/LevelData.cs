using System;
using UnityEngine;

[Serializable]
public class LevelData
{
    public int Number {  get; private set; }
    [field: SerializeField] public string EnemyName {  get; private set; }
    [field: SerializeField] public SwordsmanSpritesConfig EnemySprites {  get; private set; }

    public void SetNumber(int number)
    {
        Number = number;
    }
}
