using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SwordsmanPositioning : MonoBehaviour
{
    [SerializeField, Range(-1, 1)] private int _forwardMotionStep;
    [SerializeField] private AnimationCurve _moveSpeedOverTime;
    [SerializeField] private float _moveSpeed;

    private ArenaPositions _arenaPositions;
    private Vector2 _arenaPosition;

    [HideInInspector] public UnityEvent OnMovedBack = new();

    private Coroutine _smoothlyMove;

    public void Init(ArenaPositions arenaPositions)
    {
        _arenaPositions = arenaPositions;
    }

    public void SetPosition(Vector2 position, bool isInstantly = true)
    {
        _arenaPosition = position;

        if (isInstantly)
        {
            transform.position = position;
            return;
        }

        if (_smoothlyMove != null)
            Coroutines.StopRoutine(_smoothlyMove);

        _smoothlyMove = Coroutines.StartRoutine(MoveSmoothly(position));
    }

    public void MoveForward()
    {
        TryMove(_forwardMotionStep);
    }

    public void MoveBack()
    {
        if (TryMove(-_forwardMotionStep))
            OnMovedBack?.Invoke();
    }

    private bool TryMove(int step)
    {
        int newPositionIndex = _arenaPositions.GetIndexByPosition(_arenaPosition) + step;

        if (!_arenaPositions.IsWithin(newPositionIndex)) return false;

        Vector2 position = _arenaPositions.GetPosition(newPositionIndex);
        SetPosition(position, false);

        return true;
    }

    private IEnumerator MoveSmoothly(Vector2 position)
    {
        float initialDistance = Mathf.Abs(position.x - transform.position.x);

        do
        {
            float distance = Mathf.Abs(position.x - transform.position.x);
            float progress = 1f - (distance / initialDistance);
            float speed = _moveSpeed * _moveSpeedOverTime.Evaluate(progress);

            transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);

            yield return null;
        }
        while (Vector2.Distance(transform.position, position) > 0.05f);
    }
}
