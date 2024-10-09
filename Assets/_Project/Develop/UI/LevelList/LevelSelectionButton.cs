using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _numberView;
    [SerializeField] private TMP_Text _enemyNameView;
    [SerializeField] private Image _enemyProfieView;

    private LevelListMenu _menu;
    private int _number;

    public void Init(LevelListMenu menu, int number, string enemyName, Sprite _enemyProfile)
    {
        _menu = menu;
        _number = number;

        _numberView.text = number.ToString();
        _enemyNameView.text = enemyName;
        _enemyProfieView.sprite = _enemyProfile;
    }

    public void Openlevel()
    {
        _menu.OpenLevel(_number);
    }
}
