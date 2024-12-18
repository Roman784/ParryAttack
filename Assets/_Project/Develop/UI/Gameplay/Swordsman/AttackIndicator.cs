using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AttackIndicator : MonoBehaviour
{
    [SerializeField] private GameObject _indicatorContainer;
    [SerializeField] private Image _progressBar;

    private Coroutine _fillingCoroutine;

    public void Activate(float fillingTime)
    {
        _indicatorContainer.SetActive(true);

        Coroutines.StopRoutine(_fillingCoroutine);
        _fillingCoroutine = Coroutines.StartRoutine(FillProgressBar(fillingTime));
    }

    public void Deactivate()
    {
        _indicatorContainer.SetActive(false);
    }

    private IEnumerator FillProgressBar(float fillingTime)
    {
        for (float time = 0f; time <= fillingTime; time += Time.deltaTime)
        {
            _progressBar.fillAmount = time / fillingTime;

            yield return null;
        }

        Deactivate();
    }
}
