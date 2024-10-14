using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ThemeSelectionUI : MonoBehaviour
{
    [SerializeField] private Button _previousThemeButton;
    [SerializeField] private Button _nextThemeButton;
    [SerializeField] private Button _selectThemeButton;
    [SerializeField] private Button _unlockThemeButton;

    [Space]

    [SerializeField] private ThemeUnlockPopup _unlockPopup;

    [HideInInspector] public UnityEvent OnPreviousThemeButtonCLick = new();
    [HideInInspector] public UnityEvent OnNextThemeButtonClick = new();
    [HideInInspector] public UnityEvent OnSelectThemeButtonClick = new();
    [HideInInspector] public UnityEvent OnThemeUnlockConfirm = new();

    private void Awake()
    {
        _previousThemeButton.onClick.AddListener(() => OnPreviousThemeButtonCLick.Invoke());
        _nextThemeButton.onClick.AddListener(() => OnNextThemeButtonClick.Invoke());
        _selectThemeButton.onClick.AddListener(() => OnSelectThemeButtonClick.Invoke());
        _unlockThemeButton.onClick.AddListener(ShowUnlockPopup);

        _unlockPopup.OnYesButtonClick.AddListener(() => OnThemeUnlockConfirm.Invoke());
        _unlockPopup.OnYesButtonClick.AddListener(HideUnlockPopup);
        _unlockPopup.OnNoButtonClick.AddListener(HideUnlockPopup);

        HideUnlockPopup();
    }

    public void ShowSelectButton()
    {
        _selectThemeButton.gameObject.SetActive(true);
        _unlockThemeButton.gameObject.SetActive(false);
    }

    public void ShowUnlockButton()
    {
        _selectThemeButton.gameObject.SetActive(false);
        _unlockThemeButton.gameObject.SetActive(true);
    }

    private void ShowUnlockPopup()
    {
        _unlockPopup.gameObject.SetActive(true);
    }

    private void HideUnlockPopup()
    {
        _unlockPopup.gameObject.SetActive(false);
    }
}
