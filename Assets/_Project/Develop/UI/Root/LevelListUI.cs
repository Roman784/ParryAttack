using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Zenject;

public class LevelListUI : MonoBehaviour
{
    [SerializeField] private LevelSelectionButton _selectionButtonPrefab;
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private Transform _selectionButtonContainer;

    public LevelSelectionButton CreateButton()
    {
        var button = Instantiate(_selectionButtonPrefab);
        button.transform.SetParent(_selectionButtonContainer, false);

        _scrollRect.verticalNormalizedPosition = 1;

        return button;
    }
}
