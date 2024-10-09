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
    private int _positionIndex;

    [HideInInspector] public UnityEvent OnMovedBack = new();
    [HideInInspector] public UnityEvent OnDroppedOutOfArena = new();

    private Coroutine _smoothlyMove;

    [Inject]
    private void Construct(LevelCreator levelCreator)
    {
        _arenaPositions = levelCreator.ArenaPositions;
    }

    public void Init(int positionIndex)
    {
        SetPosition(positionIndex, true);
    }

    public int PositionIndex => _positionIndex;

    public void MoveForward()
    {
        Move(_forwardMotionStep);
    }

    public void MoveBackward()
    {
        Move(-_forwardMotionStep);
        OnMovedBack?.Invoke();
    }

    private void Move(int step)
    {
        SetPosition(_positionIndex + step);
    }

    public void SetPosition(int newPositionIndex, bool isInstantly = false)
    {
        _positionIndex = newPositionIndex;
        Vector2 position = _arenaPositions.GetPosition(_positionIndex);

        CheckForPresenceInArena();

        if (isInstantly)
        {
            transform.position = position;
            return;
        }

        Coroutines.StopRoutine(_smoothlyMove);
        _smoothlyMove = Coroutines.StartRoutine(MoveSmoothly(position));
    }

    private IEnumerator MoveSmoothly(Vector3 position)
    {
        float initialDistance = Mathf.Abs(position.x - transform.position.x);

        do
        {
            float distance = Mathf.Abs(position.x - transform.position.x);
            float progress = 1f - (distance / initialDistance);
            float speed = _moveSpeed * _moveSpeedOverTime.Evaluate(progress);

            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

            yield return null;
        }
        while (transform.position != position);
    }

    private void CheckForPresenceInArena()
    {
        if (!_arenaPositions.IsInArena(_positionIndex))
            OnDroppedOutOfArena.Invoke();
    }
}
