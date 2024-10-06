using UnityEngine;

public class ArenaGenerator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _arenaPlatfrom;

    [SerializeField] private int _arenaBlockCount;
    [SerializeField] private Vector2 _arenaBlockSize;

    [SerializeField] private GameObject _leftArenaProps;
    [SerializeField] private GameObject _rightArenaProps;

    public void Generate()
    {
        float width = _arenaBlockCount * _arenaBlockSize.x;
        float height = _arenaBlockSize.y;
        Vector2 size = new Vector2(width, height);

        _arenaPlatfrom.size = size;

        for (int i = 0; i < _arenaBlockCount; i++)
        {
            float x = LeftEdge + _arenaBlockSize.x * (i + 0.5f);
            Vector2 position = new Vector2(x, 0f);

            GameObject go = new GameObject();
            go.transform.position = position;
        }

        Instantiate(_leftArenaProps, new Vector2(LeftEdge, 0f), Quaternion.identity);
        Instantiate(_rightArenaProps, new Vector2(RightEdge, 0f), Quaternion.identity).transform.localScale = new Vector2(-1, 1);
    }

    private float LeftEdge => _arenaBlockCount / 2f * _arenaBlockSize.x * -1f;
    private float RightEdge => _arenaBlockCount / 2f * _arenaBlockSize.x;
}
