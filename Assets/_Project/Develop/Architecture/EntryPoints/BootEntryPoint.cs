using System.Collections;
using UnityEngine;
using Zenject;

public class BootEntryPoint : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public IEnumerator Run()
    {
        Debug.Log("Game boot");

        SetupGame();

        yield return new WaitForSeconds(1f);

        Debug.Log("Boot scene loaded");

        LoadStartScene();
    }

    private static void SetupGame()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // The scene where the game begins.
    private void LoadStartScene()
    {
        _sceneLoader.LoadGameplay();
    }
}
