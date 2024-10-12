using System.Collections.Generic;
using UnityEngine;

public class ArenaCreator
{
    private int _tileCount;
    private Vector2 _tileSize;

    private ThemeData _themeData;

    private SpriteRenderer _renderer;
    private List<GameObject> _props = new();

    public ArenaCreator(int width, ThemeData themeData)
    {
        _tileCount = width;
        _themeData = themeData;
        _tileSize = themeData.ArenaTileSize;
    }

    public ArenaPositions Create()
    {
        CreateRenderer();
        CreateProps();
        return CreatePositions();
    }

    public void Destroy()
    {
        Object.Destroy(_renderer.gameObject);
        foreach (GameObject props in _props)
            Object.Destroy(props);
    }

    private float LeftEdge => _tileCount / 2f * _tileSize.x * -1f;
    private float RightEdge => _tileCount / 2f * _tileSize.x;

    private void CreateRenderer()
    {
        SpriteRenderer renderer = new GameObject("Arena").AddComponent<SpriteRenderer>();
        renderer.transform.position = Vector2.zero;
        renderer.sprite = _themeData.ArenaTile;
        renderer.sortingLayerName = "Arena";
        renderer.gameObject.layer = LayerMask.NameToLayer("Arena");

        _renderer = renderer;

        SetArenaSize(renderer);
    }

    private void SetArenaSize(SpriteRenderer renderer)
    {
        float width = _tileCount * _tileSize.x;
        float height = _tileSize.y;
        Vector2 size = new Vector2(width, height);

        renderer.drawMode = SpriteDrawMode.Tiled;
        renderer.size = size;
    }

    private void CreateProps()
    {
        GameObject lefPropsPrefab = _themeData.GetRandomArenaProps();
        GameObject rightPropsPrefab = _themeData.GetRandomArenaProps();

        GameObject leftProps = Object.Instantiate(lefPropsPrefab);
        leftProps.transform.position = new Vector2(LeftEdge, 0f);

        GameObject rightProps = Object.Instantiate(rightPropsPrefab);
        rightProps.transform.position = new Vector2(RightEdge, 0f);
        rightProps.transform.localScale = new Vector2(-1, 1);

        _props.Add(leftProps);
        _props.Add(rightProps);
    }

    private ArenaPositions CreatePositions()
    {
        List<Vector2> positions = new();

        int startIndex = -1;
        int lastIndex = _tileCount;

        for (int i = startIndex; i <= lastIndex; i++)
        {
            float x = LeftEdge + _tileSize.x * (i + 0.5f);
            Vector2 position = new Vector2(x, 0f);

            positions.Add(position);
        }

        return new ArenaPositions(positions);
    }
}
