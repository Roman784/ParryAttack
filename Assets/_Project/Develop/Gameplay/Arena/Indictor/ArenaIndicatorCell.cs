using UnityEngine;
using UnityEngine.UI;

public class ArenaIndicatorCell : MonoBehaviour
{
    [SerializeField] private Image _view;

    public void Hide()
    {
        Color color = _view.color;
        color.a = 0f;

        _view.color = color;
    }
}
