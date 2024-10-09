using TMPro;
using UnityEngine;
using Zenject;

public class LevelListUI : MonoBehaviour
{
    [SerializeField] private LevelSelectionButton _selectionButtonPrefab;
    [SerializeField] private Transform _selectionButtonContainer;

    public LevelSelectionButton CreateButton()
    {
        var button = Instantiate(_selectionButtonPrefab);
        button.transform.SetParent(_selectionButtonContainer, false);

        return button;
    }
}
