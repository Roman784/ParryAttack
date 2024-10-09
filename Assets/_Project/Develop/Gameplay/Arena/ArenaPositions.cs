using System;
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
    public int Count => _positions.Count;

    public Vector2 GetPosition(int positionIndex)
    {
        positionIndex = Mathf.Clamp(positionIndex, 0, _positions.Count - 1);
        return _positions[positionIndex];
    }

    // It doesn't take into account the 2 points on the edges where there is a chasm in the arena.
    public bool IsInArena(int positionIndex)
    {
        return positionIndex > 0 && positionIndex < _positions.Count - 1;
    }
}
