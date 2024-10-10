using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [field: SerializeField] public string Name {  get; private set; }
    [field: SerializeField] public SwordsmanSpritesConfig SpritesConfig { get; private set; }
}
