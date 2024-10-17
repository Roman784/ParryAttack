using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class EducationView : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private Button _closeButton;

    [Space]

    [SerializeField] private GameObject _keyboardInputView;
    [SerializeField] private GameObject _touchscreenInputView;

    [HideInInspector] public UnityEvent OnCLoseButtonClick = new();

    private void Awake()
    {
        _closeButton.onClick.AddListener(() => OnCLoseButtonClick.Invoke());

        Hide();
    }

    public void Show()
    {
        _view.SetActive(true);
    }

    public void Hide()
    {
        _view.SetActive(false);
    }

    public void EnableKeyboardInputView()
    {
        _keyboardInputView.SetActive(true);
        _touchscreenInputView.SetActive(false);

        GetComponent<Animator>().SetTrigger("KeyboardInput");
    }

    public void EnableTouchscreenInputView()
    {
        _keyboardInputView.SetActive(false);
        _touchscreenInputView.SetActive(true);

        GetComponent<Animator>().SetTrigger("TouchscreenInput");
    }
}
