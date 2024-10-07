using System.Collections.Generic;
using UnityEngine;

public class ArenaPositions
{
    private List<Vector2> _positions;

    public ArenaPositions(List<Vector2> positions)
    {
        _positions = new List<Vector2>(positions);
    }

    public IEnumerable<Vector2> Positions => _positions;

    public Vector2 PlayerPosition => _positions[_positions.Count / 2 - 1];
    public Vector2 EnemyPosition => _positions[_positions.Count / 2];

    public Vector2 GetPosition(int i)
    {
        if (!IsWithin(i)) return Vector2.zero;

        return _positions[i];
    }

    public bool IsWithin(int i)
    {
        return i >= 0 && i < _positions.Count;
    }

    public int GetIndexByPosition(Vector2 position)
    {
        return _positions.IndexOf(position);
    }

    public bool InArena(Vector2 position)
    {
        int i = GetIndexByPosition(position);
        return i > 0 && i < _positions.Count - 1;
    }
}
