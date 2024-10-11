using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FightResultHandlerView : MonoBehaviour
{
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _nexLevelButton;

    private void Awake()
    {
        HideButtons();

        _retryButton.onClick.AddListener(() => OnRetryButtonClicked.Invoke());
        _nexLevelButton.onClick.AddListener(() => OnNexLevelButtonClicked.Invoke());
    }

    [HideInInspector] public UnityEvent OnRetryButtonClicked = new();
    [HideInInspector] public UnityEvent OnNexLevelButtonClicked = new();

    public void ShowRetryButton()
    {
        _retryButton.gameObject.SetActive(true);
    }

    public void ShowNextLevelButton()
    {
        _nexLevelButton.gameObject.SetActive(true);
    }

    private void HideButtons()
    {
        _retryButton.gameObject.SetActive(false);
        _nexLevelButton.gameObject.SetActive(false);
    }
}
