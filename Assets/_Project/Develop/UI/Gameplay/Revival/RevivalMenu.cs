using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RevivalMenu : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private Image _indicatorView;

    private Action<bool> _onRevive;

    private void Awake()
    {
        Close();
    }

    public void Revive()
    {
        _onRevive?.Invoke(true);
        Close();
    }

    public void Refuse()
    {
        _onRevive.Invoke(false);
        Close();
    }

    public void Open(Action<bool> callback)
    {
        _view.SetActive(true);
        _onRevive = callback;
        Coroutines.StartRoutine(Timer(3f));
    }

    private void Close()
    {
        _view.SetActive(false);
    }

    private IEnumerator Timer(float duration)
    {
        for (float time = 0; time < duration; time += Time.deltaTime)
        {
            _indicatorView.fillAmount = time / duration;

            yield return null;
        }

        Refuse();
    }
}
