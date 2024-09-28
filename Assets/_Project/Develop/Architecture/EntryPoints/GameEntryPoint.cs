using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    private static GameEntryPoint _instance;

    private UIRoot _uiRoot;
    private SceneLoader _sceneLoader;

    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

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
        _sceneLoader.LoadAndStartGameplay(_uiRoot);
    }

    private void CreateUIRoot()
    {
        var uiRootPrefab = Resources.Load<UIRoot>("UIRoot");
        _uiRoot = Object.Instantiate(uiRootPrefab);
        Object.DontDestroyOnLoad(_uiRoot.gameObject);
    }
}
