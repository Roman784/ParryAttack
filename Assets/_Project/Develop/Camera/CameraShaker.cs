using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShaker 
{
    private CameraConfig _config;
    private Transform _target;

    private Vector3 _initialTargetPosition;
    private Coroutine _shaking;

    public CameraShaker(CameraConfig config)
    {
        _config = config;
        _target = Camera.main.transform;
    }

    public void ShakeWeakly(Vector2 direction)
    {
        Shake(_config.WeakShakeDuration, _config.WeakShakeOverTime, direction);
    }

    private void Shake(float duration, AnimationCurve changesOverTime, Vector2 direction)
    {
        if (_shaking != null)
        {
            Coroutines.StopRoutine(_shaking);
            _target.localPosition = _initialTargetPosition;
        }

        _initialTargetPosition = _target.localPosition;
        _shaking = Coroutines.StartRoutine(Shaking(duration, changesOverTime, direction));
    }

    private IEnumerator Shaking(float duration, AnimationCurve offsetOverTime, Vector2 direction)
    {
        Vector3 initialPosition = _target.localPosition;

        for (float time = 0f; time < duration; time += Time.deltaTime)
        {
            float progress = time / duration;
            Vector3 position = initialPosition + offsetOverTime.Evaluate(progress) * (Vector3)direction;

            _target.localPosition = position;

            yield return null;
        }

        _target.localPosition = initialPosition;
    }
}
