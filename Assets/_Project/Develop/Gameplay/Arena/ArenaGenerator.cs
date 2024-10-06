using System.Collections.Generic;
using UnityEngine;

public class ArenaGenerator
{
    private SpriteRenderer _renderer;
    private int _tileCount;
    private Vector2 _tileSize;

    private ArenaPositions _positions;

    private ThemeConfig _themeConfig;

    public ArenaGenerator(int width, ThemeConfig themeConfig)
    {
        _tileCount = width;
        _themeConfig = themeConfig;
        _tileSize = themeConfig.ArenaTileSize;
    }

    public void Generate()
    {
        CreateRenderer();
        SetArenaSize();
        InitPositions();
        CreateProps();
    }

    public ArenaPositions Positions => _positions;

    private float LeftEdge => _tileCount / 2f * _tileSize.x * -1f;
    private float RightEdge => _tileCount / 2f * _tileSize.x;

    private void CreateRenderer()
    {
        _renderer = new GameObject("Arena").AddComponent<SpriteRenderer>();
        _renderer.transform.position = Vector2.zero;
        _renderer.sprite = _themeConfig.ArenaTile;
    }

    private void SetArenaSize()
    {
        float width = _tileCount * _tileSize.x;
        float height = _tileSize.y;
        Vector2 size = new Vector2(width, height);

        _renderer.drawMode = SpriteDrawMode.Tiled;
        _renderer.size = size;
    }

    private void InitPositions()
    {
        List<Vector2> positions = new();

        for (int i = 0; i < _tileCount; i++)
        {
            float x = LeftEdge + _tileSize.x * (i + 0.5f);
            Vector2 position = new Vector2(x, 0f);

            positions.Add(position);
        }

        _positions = new ArenaPositions(positions);
    }

    private void CreateProps()
    {
        GameObject lefPropsPrefab = _themeConfig.GetRandomArenaProps();
        GameObject rightPropsPrefab = _themeConfig.GetRandomArenaProps();

        GameObject leftProps = Object.Instantiate(lefPropsPrefab);
        leftProps.transform.position = new Vector2(LeftEdge, 0f);

        GameObject rightProps = Object.Instantiate(rightPropsPrefab);
        rightProps.transform.position = new Vector2(RightEdge, 0f);
        rightProps.transform.localScale = new Vector2(-1, 1);
    }
}
