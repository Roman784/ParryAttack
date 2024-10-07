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

    private List<Transform> _cells = new();

    public ArenaPositionIndicator(ArenaPositionIndicatorView view, ArenaPositions arenaPositions, Player player, Enemy enemy)
    {
        _view = view;
        _arenaPositions = arenaPositions;
        _player = player.Positioning;
        _enemy = enemy.Positioning;

        _player.OnMovedBack.AddListener(() => MovePlayerTracker());
        _enemy.OnMovedBack.AddListener(() => MoveEnemyTracker());

        CreateCells();
    }

    private void CreateCells()
    {
        int count = _arenaPositions.Positions.Count() - 2;

        for (int i = 0; i < count; i++)
        {
            GameObject cell = _view.CreateCell();
            _cells.Add(cell.transform);
        }
    }

    private void MovePlayerTracker()
    {
        int positionIndex = _arenaPositions.GetIndexByPosition(_player.ArenaPosition) - 1;

        if (positionIndex < 0) return;

        MoveTrackers(positionIndex, positionIndex + 1);
    }

    private void MoveEnemyTracker()
    {
        int positionIndex = _arenaPositions.GetIndexByPosition(_enemy.ArenaPosition) - 1;

        if (positionIndex >= _cells.Count) return;

        MoveTrackers(positionIndex - 1, positionIndex);
    }

    private void MoveTrackers(int playerIndex, int enemyIndex)
    {
        Vector2 playerTrackerPosition = GetCellPosition(playerIndex);
        Vector2 enemyTrackerPosition = GetCellPosition(enemyIndex);

        _view.SetPlayerTrackerPosition(playerTrackerPosition);
        _view.SetEnemyTrackerPosition(enemyTrackerPosition);
    }

    private Vector2 GetCellPosition(int i)
    {
        if (i < 0 || i >= _cells.Count)
            throw new ArgumentOutOfRangeException("The index is out of the arena cell list.");

        return _cells[i].position;
    }
}
