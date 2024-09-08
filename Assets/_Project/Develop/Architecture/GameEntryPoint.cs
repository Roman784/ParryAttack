using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    private static GameEntryPoint _instance;

    private UIRoot _uiRoot;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutostartGame()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        _instance = new GameEntryPoint();
        _instance.RunGame();
    }

    private GameEntryPoint()
    {
        CreateUIRoot();
    }

    private void RunGame()
    {
        Coroutines.StartRoutine(LoadAndStartGameplay());
    }

    private IEnumerator LoadAndStartGameplay()
    {
        _uiRoot.ShowLoadingScreen();

        yield return LoadScene(Scenes.BOOT);

        BootEntryPoint bootEntryPoint = Object.FindFirstObjectByType<BootEntryPoint>();
        yield return bootEntryPoint.Run();

        yield return LoadScene(Scenes.GAMEPLAY);

        GameplayEntryPoint sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
        yield return sceneEntryPoint.Run();

        _uiRoot.HideLoadingScreen();
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return null;
    }

    private void CreateUIRoot()
    {
        var uiRootPrefab = Resources.Load<UIRoot>("UIRoot");
        _uiRoot = Object.Instantiate(uiRootPrefab);
        Object.DontDestroyOnLoad(_uiRoot.gameObject);
    }
}
