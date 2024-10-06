using UnityEngine;

[CreateAssetMenu(fileName = "ThemeConfig", menuName = "Configs/Theme")]
public class ThemeConfig : ScriptableObject
{
    [field: SerializeField] public Sprite ArenaTile {  get; private set; }
    [field: SerializeField] public Vector2 ArenaTileSize { get; private set; }
    [field: SerializeField] public GameObject[] ArenaProps { get; private set; }

    public GameObject GetRandomArenaProps()
    {
        int i = Random.Range(0, ArenaProps.Length);
        return ArenaProps[i];
    }
}
