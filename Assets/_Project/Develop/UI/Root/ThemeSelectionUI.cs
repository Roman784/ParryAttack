using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ThemeSelectionUI : MonoBehaviour
{
    [SerializeField] private Button _previousThemeButton;
    [SerializeField] private Button _nextThemeButton;
    [SerializeField] private Button _selectThemeButton;

    [HideInInspector] public UnityEvent OnPreviousThemeButtonCLick = new();
    [HideInInspector] public UnityEvent OnNextThemeButtonClick = new();
    [HideInInspector] public UnityEvent OnSelectThemeButtonClick = new();

    private void Awake()
    {
        _previousThemeButton.onClick.AddListener(() => OnPreviousThemeButtonCLick.Invoke());
        _nextThemeButton.onClick.AddListener(() => OnNextThemeButtonClick.Invoke());
        _selectThemeButton.onClick.AddListener(() => OnSelectThemeButtonClick.Invoke());
    }
}
