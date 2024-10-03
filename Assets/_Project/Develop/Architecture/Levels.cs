using System;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public List<Level> LevelsList = new();
}

[Serializable]
public class Level
{
    public string EnemyName;
    public int EnemyHeartCount;
    public SwordsmanSpritesConfig EnemySprites;
    public DifficultyChangesConfig DifficultyChanges;
}
