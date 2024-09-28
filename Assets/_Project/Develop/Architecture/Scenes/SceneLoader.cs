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
        Coroutines.StartRoutine(
            LoadScene<GameplayEntryPoint>(Scenes.GAMEPLAY));
    }

    private IEnumerator LoadScene<T>(string sceneName) where T : EntryPoint
    {
        _uiRoot.ShowLoadingScreen();

        yield return SceneManager.LoadSceneAsync(sceneName);

        EntryPoint sceneEntryPoint = Object.FindFirstObjectByType<T>();
        yield return sceneEntryPoint.Run();

        _uiRoot.HideLoadingScreen();
    }
}
