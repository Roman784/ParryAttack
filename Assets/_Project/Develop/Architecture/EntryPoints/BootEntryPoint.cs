using System.Collections;
using UnityEngine;
using Zenject;

public class BootEntryPoint : EntryPoint
{
    private SceneLoader _sceneLoader;
    private LevelTracker _levelTracker;

    [Inject]
    private void Construct(SceneLoader sceneLoader, LevelTracker levelTracker)
    {
        _sceneLoader = sceneLoader;
        _levelTracker = levelTracker;
    }

    public override IEnumerator Run()
    {
        yield return null;

        SetupGame();
        SetCurrentLevel();

        LoadStartScene();
    }

    private void SetupGame()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void SetCurrentLevel()
    {
        _levelTracker.SetCurrentLevelNumber(1); // <- From storage.
    }

    // The scene where the game begins.
    private void LoadStartScene()
    {
        _sceneLoader.LoadGameplay();
    }
}
