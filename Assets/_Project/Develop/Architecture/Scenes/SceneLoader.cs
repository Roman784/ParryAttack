using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void LoadAndStartGameplay(UIRoot uiRoot)
    {
        Coroutines.StartRoutine(LoadAndStartGameplayRoutine(uiRoot));
    }

    private IEnumerator LoadAndStartGameplayRoutine(UIRoot uiRoot)
    {
        uiRoot.ShowLoadingScreen();

        yield return LoadScene(Scenes.BOOT);

        BootEntryPoint bootEntryPoint = Object.FindFirstObjectByType<BootEntryPoint>();
        yield return bootEntryPoint.Run();

        yield return LoadScene(Scenes.GAMEPLAY);

        GameplayEntryPoint sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
        yield return sceneEntryPoint.Run(uiRoot);

        uiRoot.HideLoadingScreen();
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return null;
    }
}
