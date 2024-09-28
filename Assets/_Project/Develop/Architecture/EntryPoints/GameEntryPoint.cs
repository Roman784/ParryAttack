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

        EntryPoint bootEntryPoint = Object.FindFirstObjectByType<BootEntryPoint>();
        yield return bootEntryPoint.Run();
    }
}
