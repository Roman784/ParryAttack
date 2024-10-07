using UnityEngine;

public class ArenaPositionIndicatorView : MonoBehaviour
{
    [SerializeField] private Transform _playerTracker;
    [SerializeField] private Transform _enemyTracker;

    [Space]

    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private Transform _cellContainer;

    public GameObject CreateCell()
    {
        return Instantiate(_cellPrefab, transform.position, Quaternion.identity, _cellContainer);
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
