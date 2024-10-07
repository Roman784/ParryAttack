using UnityEngine;

public class GameplayCamera : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 _offset;

    private CameraMovement _movement;
    private CameraShaker _shaker;

    public void Init(Transform player, Transform enemy)
    {
        _movement = new CameraMovement(transform, _moveSpeed, _offset, player, enemy);
        _shaker = new CameraShaker();
    }

    private void Update()
    {
        _movement?.Move(Time.deltaTime);
    }

    public CameraShaker Shaker => _shaker;
}
