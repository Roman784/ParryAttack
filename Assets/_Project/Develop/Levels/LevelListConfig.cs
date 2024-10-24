using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "LevelListConfig", menuName = "Configs/LevelList")]
public class LevelListConfig : ScriptableObject
{
    public List<LevelData> Levels = new();

    private void OnValidate()
    {
        //SetNumbers();
        ValidateArenaWidth();
    }

    // Sets the level numbers based on the location in the list.
    [ContextMenu("Set numbers")]
    private void SetNumbers()
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            int number = i + 1;
            Levels[i].SetNumber(number);
        }
    }

    private void ValidateArenaWidth()
    {
        foreach(var level in Levels)
        {
            if (level.ArenaWidth % 2 != 0)
                throw new ArgumentException($"The width of all arenas shall be even.\nLevel number: {level.Number}");

            if (level.ArenaWidth < 2)
                throw new ArgumentException($"The width of all arenas shall be greater than 2.\nLevel number: {level.Number}");
        }
    }
}
