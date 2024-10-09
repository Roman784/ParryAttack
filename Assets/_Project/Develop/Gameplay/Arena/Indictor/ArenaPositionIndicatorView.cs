using UnityEngine;

public class ArenaPositionIndicatorView : MonoBehaviour
{
    [SerializeField] private Transform _playerTracker;
    [SerializeField] private Transform _enemyTracker;

    [Space]

    [SerializeField] private ArenaIndicatorCell _cellPrefab;
    [SerializeField] private Transform _cellContainer;

    public ArenaIndicatorCell CreateCell()
    {
        ArenaIndicatorCell cell = Instantiate(_cellPrefab);
        cell.transform.SetParent(_cellContainer, false);

        return cell;
    }

    public void SetPlayerTrackerPosition(Vector2 position)
    {
        position.y = _playerTracker.position.y;
        _playerTracker.position = position;
    }

    public void SetEnemyTrackerPosition(Vector2 position)
    {
        position.y = _enemyTracker.position.y;
        _enemyTracker.position = position;
    }
}
