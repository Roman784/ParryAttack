using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void RunGame()
    {
        Debug.Log("Run game");
        Coroutines.StartRoutine(LoadBootScene());
    }

    private static IEnumerator LoadBootScene()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("11111111111");
        yield return SceneManager.LoadSceneAsync(Scenes.BOOT);
        yield return new WaitForSeconds(2);
        Debug.Log("222222222222");

        EntryPoint bootEntryPoint = Object.FindFirstObjectByType<BootEntryPoint>();
        yield return bootEntryPoint.Run();
    }
}
