using System.Collections;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : EntryPoint
{
    private UIRoot _uiRoot;
    private GameplayUI _gameplayUI;

    [Inject]
    private void Construct(UIRoot uIRoot, GameplayUI gameplayUI)
    {
        _uiRoot = uIRoot;
        _gameplayUI = gameplayUI;
    }

    public override IEnumerator Run()
    {
        GameplayUI gameplayUI = Instantiate(_gameplayUI);
        _uiRoot.AttachSceneUI(gameplayUI.transform);

        yield return null;

        Debug.Log("Gameplay scene loaded");
    }
}
