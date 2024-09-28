using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void RunGame()
    {
        Coroutines.StartRoutine(LoadBootScene());
    }

    private static IEnumerator LoadBootScene()
    {
        yield return SceneManager.LoadSceneAsync(Scenes.BOOT);

        BootEntryPoint bootEntryPoint = Object.FindFirstObjectByType<BootEntryPoint>();
        yield return bootEntryPoint.Run();
    }
}
