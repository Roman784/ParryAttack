using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TranslationsConfig", menuName = "Configs/Translations")]
public class TranslationsConfig : ScriptableObject
{
    [field: SerializeField] public List<TranslationData> Enemies = new();
    [field: SerializeField] public List<TranslationData> UI = new();
}

[System.Serializable]
public class TranslationData
{
    [field: SerializeField] public string Key { get; private set; }

    [field: Space]
    [field: SerializeField] public string En { get; private set; }
    [field: SerializeField] public string Ru { get; private set; }
    [field: SerializeField] public string Tr { get; private set; }
}
