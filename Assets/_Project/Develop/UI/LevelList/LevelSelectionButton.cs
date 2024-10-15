using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _numberView;
    [SerializeField] private TMP_Text _enemyNameView;
    [SerializeField] private Image _enemyProfieView;

    [SerializeField] private GameObject _profileBlackoutView;
    [SerializeField] private GameObject _blackoutView;

    private LevelListMenu _menu;
    private string _enemyName;
    private int _number;

    private bool _isLock;

    public void Init(LevelListMenu menu, int number, string enemyName, Sprite _enemyProfile)
    {
        _menu = menu;
        _enemyName = enemyName;
        _number = number;

        _numberView.text = number.ToString();
        _enemyNameView.text = enemyName;
        _enemyProfieView.sprite = _enemyProfile;
    }

    public void Openlevel()
    {
        if (_isLock) return;

        _menu.OpenLevel(_number);
    }

    public void Lock()
    {
        _isLock = true;

        _enemyNameView.text = "???";
        _profileBlackoutView.SetActive(true);
        _blackoutView.SetActive(true);
    }

    public void Unlock()
    {
        _isLock = false;

        _enemyNameView.text = _enemyName;
        _profileBlackoutView.SetActive(false);
        _blackoutView.SetActive(false);
    }
}
