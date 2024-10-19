using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float AudioVolume;

    [Space]

    public int LastCompletedLevel;

    [Space]

    public int CurrentTheme;
    public List<int> UnlockedThemes = new();

    [Space]

    public bool IsFirstEntry;
}
