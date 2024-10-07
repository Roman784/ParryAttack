using UnityEngine;

public class CameraMovement
{
    private Transform _transform;
    private float _moveSpeed;
    private Vector3 _offset;

    private Transform _player;
    private Transform _enemy;

    public CameraMovement(Transform transfrom, float moveSpeed, Vector3 offset, Transform player, Transform enemy)
    {
        _transform = transfrom;
        _moveSpeed = moveSpeed;
        _offset = offset;
        _player = player;
        _enemy = enemy;
    }

    public void Move(float delta)
    {
        if (_player == null || _enemy == null) return;

        Vector2 position = (_player.position + _enemy.position) / 2f + _offset;
        _transform.position = Vector2.Lerp(_transform.position, position, _moveSpeed * delta);
    }
}
