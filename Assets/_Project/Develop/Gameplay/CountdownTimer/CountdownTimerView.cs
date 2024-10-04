using TMPro;
using UnityEngine;

public class CountdownTimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerView;

    public void UpdateTimer(int newTime)
    {
        _timerView.text = newTime.ToString();
    }

    public void Enable()
    {
        _timerView.gameObject.SetActive(true);
    }

    public void Disable()
    {
        _timerView?.gameObject.SetActive(false);
    }
}
