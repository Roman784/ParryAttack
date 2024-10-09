using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _numberView;
    [SerializeField] private TMP_Text _enemyNameView;
    [SerializeField] private Image _enemyProfieView;

    public void Init(int number, string enemyName, Sprite _enemyProfile)
    {
        _numberView.text = number.ToString();
        _enemyNameView.text = enemyName;
        _enemyProfieView.sprite = _enemyProfile;
    }
}
