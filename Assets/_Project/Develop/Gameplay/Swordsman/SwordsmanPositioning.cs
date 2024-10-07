using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class SwordsmanPositioning : MonoBehaviour
{
    [SerializeField, Range(-1, 1)] private int _forwardMotionStep;
    [SerializeField] private AnimationCurve _moveSpeedOverTime;
    [SerializeField] private float _moveSpeed;

    private ArenaPositions _arenaPositions;
    private Vector2 _arenaPosition;

    [HideInInspector] public UnityEvent OnMovedBack = new();

    private Coroutine _smoothlyMove;

    [Inject]
    private void Construct(LevelCreator levelCreator)
    {
        _arenaPositions = levelCreator.ArenaPositions;
    }

    public void Init()
    {
    }

    public bool InArena()
    {
        return _arenaPositions.InArena(_arenaPosition);
    }

    public void SetInitialPositionForPlayer()
    {
        SetPosition(_arenaPositions.PlayerPosition);
    }

    public void SetInitialPositionForEnemy()
    {
        SetPosition(_arenaPositions.EnemyPosition);
    }

    public void SetPosition(Vector2 position, bool isInstantly = true)
    {
        _arenaPosition = position;

        if (isInstantly)
        {
            transform.position = position;
        }
        else
        {
            if (_smoothlyMove != null)
                Coroutines.StopRoutine(_smoothlyMove);

            _smoothlyMove = Coroutines.StartRoutine(MoveSmoothly(position));
        }
    }

    public void MoveForward()
    {
        Move(_forwardMotionStep);
    }

    public void MoveBack()
    {
        Move(-_forwardMotionStep);
        OnMovedBack?.Invoke();
    }

    private void Move(int step)
    {
        int newPositionIndex = _arenaPositions.GetIndexByPosition(_arenaPosition) + step;

        Vector2 position = _arenaPositions.GetPosition(newPositionIndex);
        SetPosition(position, false);
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
