using UnityEngine;

[System.Serializable]
public class ThemeData
{
    [field: SerializeField] public int Key {  get; private set; }

    [field: Space]
    [field: SerializeField] public Sprite ArenaTile { get; private set; }
    [field: SerializeField] public Vector2 ArenaTileSize { get; private set; }
    [field: SerializeField] public GameObject[] ArenaProps { get; private set; }
    [field: SerializeField] public Theme Prefab { get; private set; }
    [field: SerializeField] public Color SkyColor { get; private set; }

    public GameObject GetRandomArenaProps()
    {
        int i = Random.Range(0, ArenaProps.Length);
        return ArenaProps[i];
    }
}
