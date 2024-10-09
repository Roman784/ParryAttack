using System.Collections;
using UnityEngine;

public class CameraShaker 
{
    private CameraConfig _config;
    private Transform _target;

    private Vector3 _initialPosition;
    private Coroutine _shaking;

    public CameraShaker(CameraConfig config)
    {
        _config = config;
        _target = Camera.main.transform;

        _initialPosition = _target.localPosition;
    }

    public void Shake(Vector2 direction)
    {
        StopShaking();
        _shaking = Coroutines.StartRoutine(Shaking(_config.ShakeDuration, _config.ShakeOverTime, direction));
    }

    private IEnumerator Shaking(float duration, AnimationCurve offsetOverTime, Vector2 direction)
    {
        for (float time = 0f; time < duration; time += Time.deltaTime)
        {
            float progress = time / duration;
            Vector3 position = _initialPosition + offsetOverTime.Evaluate(progress) * (Vector3)direction;

            _target.localPosition = position;

            yield return null;
        }

        _target.localPosition = _initialPosition;
    }

    private void StopShaking()
    {
        Coroutines.StopRoutine(_shaking);
        _target.localPosition = _initialPosition;
    }
}
