using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class ArenaPositionIndicator
{
    private ArenaPositionIndicatorView _view;
    private ArenaPositions _arenaPositions;

    private SwordsmanPositioning _player;
    private SwordsmanPositioning _enemy;

    private List<ArenaIndicatorCell> _cells = new();

    public ArenaPositionIndicator(ArenaPositionIndicatorView view, ArenaPositions arenaPositions, Player player, Enemy enemy)
    {
        _view = view;
        _arenaPositions = arenaPositions;
        _player = player.Positioning;
        _enemy = enemy.Positioning;

        _player.OnMovedBack.AddListener(() => MoveTrackers());
        _enemy.OnMovedBack.AddListener(() => MoveTrackers());

        CreateCells();
        HideEdgeCells();
    }

    private void CreateCells()
    {
        int count = _arenaPositions.Positions.Count();

        for (int i = 0; i < count; i++)
        {
            ArenaIndicatorCell cell = _view.CreateCell();
            _cells.Add(cell);
        }
    }

    // These cells will display positions outside of the arena.
    private void HideEdgeCells()
    {
        _cells[0].Hide();
        _cells[_cells.Count - 1].Hide();
    }

    private void MoveTrackers()
    {
        Vector2 playerTrackerPosition = GetCellPosition(_player.PositionIndex);
        Vector2 enemyTrackerPosition = GetCellPosition(_enemy.PositionIndex);

        _view.SetPlayerTrackerPosition(playerTrackerPosition);
        _view.SetEnemyTrackerPosition(enemyTrackerPosition);
    }

    private Vector2 GetCellPosition(int i)
    {
        if (i < 0 || i >= _cells.Count)
            throw new ArgumentOutOfRangeException("The index is out of the arena cell list.");

        return _cells[i].transform.position;
    }
}
