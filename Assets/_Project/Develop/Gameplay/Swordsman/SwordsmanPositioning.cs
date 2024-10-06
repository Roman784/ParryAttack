using UnityEngine;
using UnityEngine.Events;

public class SwordsmanPositioning : MonoBehaviour
{
    [SerializeField, Range(-1, 1)] private int _forwardMotionStep;

    private ArenaPositions _arenaPositions;
    private Vector2 _arenaPosition;

    public UnityEvent<int> OnMovedBack = new();

    public void Init(ArenaPositions arenaPositions)
    {
        _arenaPositions = arenaPositions;
    }

    public void SetPosition(Vector2 position)
    {
        _arenaPosition = position;
        transform.position = position;
    }

    public void MoveBack()
    {
        Move(-_forwardMotionStep);
        OnMovedBack?.Invoke(-_forwardMotionStep);
    }

    public void Move(int step)
    {
        Debug.Log("aaaaaa");
        int newPositionIndex = _arenaPositions.GetIndexByPosition(_arenaPosition) + step;

        if (!_arenaPositions.IsWithin(newPositionIndex)) return;

        Vector2 position = _arenaPositions.GetPosition(newPositionIndex);
        SetPosition(position);
    }
}
