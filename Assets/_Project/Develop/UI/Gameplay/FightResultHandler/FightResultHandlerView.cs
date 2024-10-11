using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class FightResultHandlerView : MonoBehaviour
{
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _nexLevelButton;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        HideButtons();

        _retryButton.onClick.AddListener(() => OnRetryButtonClicked.Invoke());
        _nexLevelButton.onClick.AddListener(() => OnNexLevelButtonClicked.Invoke());
    }

    [HideInInspector] public UnityEvent OnRetryButtonClicked = new();
    [HideInInspector] public UnityEvent OnNexLevelButtonClicked = new();

    public void ShowRetryButton()
    {
        _retryButton.gameObject.SetActive(true);
        _animator.SetTrigger("ShowRetryButton");
    }

    public void ShowNextLevelButton()
    {
        _nexLevelButton.gameObject.SetActive(true);
        _animator.SetTrigger("ShowNextLevelButton");
    }

    private void HideButtons()
    {
        _retryButton.gameObject.SetActive(false);
        _nexLevelButton.gameObject.SetActive(false);
    }
}
