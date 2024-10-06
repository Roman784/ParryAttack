using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemesConfig", menuName = "Configs/Themes")]
public class ThemesConfig : ScriptableObject
{
    [SerializeField] private List<ThemeData> _themes = new List<ThemeData>();

    public List<ThemeData> Themes => new List<ThemeData>(_themes);
}
