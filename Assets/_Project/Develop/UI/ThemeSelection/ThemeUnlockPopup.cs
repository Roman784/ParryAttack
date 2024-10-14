using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ThemeUnlockPopup : MonoBehaviour
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    [HideInInspector] public UnityEvent OnYesButtonClick = new();
    [HideInInspector] public UnityEvent OnNoButtonClick = new();

    private void Awake()
    {
        _yesButton.onClick.AddListener(() => OnYesButtonClick.Invoke());
        _noButton.onClick.AddListener(() => OnNoButtonClick.Invoke());
    }
}
