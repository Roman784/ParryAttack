using System.Collections;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : EntryPoint
{
    private GameplayUI _gameplayUI;

    [Inject]
    private void Construct( GameplayUI gameplayUI)
    {
        _gameplayUI = gameplayUI;
    }

    public override IEnumerator Run()
    {
        GameplayUI gameplayUI = Instantiate(_gameplayUI);
        UIRoot.AttachSceneUI(gameplayUI.transform);

        yield return null;

        Debug.Log("Gameplay scene loaded");
    }
}
