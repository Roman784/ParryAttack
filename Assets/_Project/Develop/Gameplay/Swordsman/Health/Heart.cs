using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] private Image _renderer;
    [SerializeField] private Sprite _fullSprite;
    [SerializeField] private Sprite _emptySprite;

    private bool _isEmpty;

    private void Awake()
    {
        _isEmpty = false;

        SetSprite();
    }

    public void Spend()
    {
        _isEmpty = true;
        SetSprite();
    }

    private void SetSprite()
    {
        if (_isEmpty) _renderer.sprite = _emptySprite;
        else _renderer.sprite = _fullSprite;
    }

    public bool IsEmpty => _isEmpty;
}
