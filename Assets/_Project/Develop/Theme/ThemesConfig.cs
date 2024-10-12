using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemesConfig", menuName = "Configs/Themes")]
public class ThemesConfig : ScriptableObject
{
    [SerializeField] private List<ThemeData> _themes = new List<ThemeData>();

    public List<ThemeData> Themes => new List<ThemeData>(_themes);

    private void OnValidate()
    {
        ValidateKey();
    }

    private void ValidateKey()
    {
        var res = _themes.GroupBy(theme => theme.Key)
                         .Any(group => group.Count() > 1);

        if (res)
            throw new Exception($"Several themes have matching keys");
    }
}
