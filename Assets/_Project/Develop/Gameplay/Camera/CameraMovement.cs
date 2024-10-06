using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 _offset;

    private Transform _player;
    private Transform _enemy;

    public void Init(Transform player, Transform enemy)
    {
        _player = player;
        _enemy = enemy;
    }

    private void Update()
    {
        Move(Time.deltaTime);
    }

    private void Move(float delta)
    {
        if (_player == null || _enemy == null) return;

        Vector2 position = (_player.position + _enemy.position) / 2f + _offset;
        transform.position = Vector2.Lerp(transform.position, position, _moveSpeed * delta);
    }
}
