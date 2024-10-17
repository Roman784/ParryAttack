using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EducationView : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private Button _closeButton;

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
}
