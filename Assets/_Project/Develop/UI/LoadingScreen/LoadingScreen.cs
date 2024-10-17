using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image _background;

    [Space]

    [SerializeField] private float _duration;
    [SerializeField] private AnimationCurve _appearanceOverTime;
    [SerializeField] private AnimationCurve _disappearanceOverTime;

    public IEnumerator Show()
    {
        _background.gameObject.SetActive(true);
        yield return Coroutines.StartRoutine(ChangeTransparency(_duration, _appearanceOverTime));
    }

    public IEnumerator Hide()
    {
        yield return Coroutines.StartRoutine(ChangeTransparency(_duration, _disappearanceOverTime));
        _background.gameObject.SetActive(false);
    }

    public void HideInstantly()
    {
        _background.gameObject.SetActive(false);
    }

    private IEnumerator ChangeTransparency(float duration, AnimationCurve changesOverTime)
    {
        Color color = _background.color;

        for (float time = 0f; time <= duration; time += Time.deltaTime)
        {
            float progress = time / duration;

            color.a = changesOverTime.Evaluate(progress);
            _background.color = color;

            yield return null;
        }
    }
}
