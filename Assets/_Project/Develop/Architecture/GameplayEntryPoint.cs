using System.Collections;
using UnityEngine;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField] private GameplayUI _gameplayUI;

    public IEnumerator Run(UIRoot uiRoot)
    {
        GameplayUI gameplayUI = Instantiate(_gameplayUI);
        uiRoot.AttachSceneUI(gameplayUI.transform);

        yield return null;
    }
}
