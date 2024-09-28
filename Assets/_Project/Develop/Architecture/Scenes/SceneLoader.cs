using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader
{
    private UIRoot _uiRoot;

    [Inject]
    private void Construct(UIRoot uIRoot)
    {
        _uiRoot = uIRoot;
    }

    public void LoadGameplay()
    {
        Coroutines.StartRoutine(LoadAndRunGameplayRoutine());
    }

    private IEnumerator LoadAndRunGameplayRoutine()
    {
        _uiRoot.ShowLoadingScreen();

        yield return LoadScene(Scenes.GAMEPLAY);

        GameplayEntryPoint sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
        yield return sceneEntryPoint.Run();

        _uiRoot.HideLoadingScreen();
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
