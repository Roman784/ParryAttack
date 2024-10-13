using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int LastCompletedLevel;

    [Space]

    public int CurrentTheme;
    public List<int> UnlockedThemes = new();
}
