using System.Collections;
using UnityEngine;
using Zenject;

public class BootEntryPoint : EntryPoint
{
    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public override IEnumerator Run()
    {
        SetupGame();

        yield return new WaitForSeconds(0.5f);

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
