using UnityEngine;
using Zenject;

public class GameplayCamera : MonoBehaviour
{
    private CameraConfig _config;

    private CameraMovement _movement;
    private CameraShaker _shaker;

    [Inject]
    private void Construct(CameraConfig config)
    {
        _config = config;
    }

    public void Init(Transform player, Transform enemy)
    {
        _movement = new CameraMovement(_config, transform, player, enemy);
        _shaker = new CameraShaker(_config);
    }

    private void Update()
    {
        _movement?.Move(Time.deltaTime);
    }

    public CameraShaker Shaker => _shaker;
}
