using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelListConfig", menuName = "Configs/LevelList")]
public class LevelListConfig : ScriptableObject
{
    public List<LevelData> Levels = new();

    private void OnValidate()
    {
        SetNumbers();
    }

    // Sets the level numbers based on the location in the list.
    private void SetNumbers()
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            int number = i + 1;
            Levels[i].SetNumber(number);
        }
    }
}
