using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Text))]
public class TextLocalization : MonoBehaviour
{
    [SerializeField] private string _key;

    [Inject]
    private void Construct(Translator translator)
    {
        GetComponent<TMP_Text>().text = translator.GetUI(_key);
    }
}
