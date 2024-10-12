using System.Collections;
using UnityEngine;
using Zenject;

public class BootEntryPoint : EntryPoint
{
    private SceneLoader _sceneLoader;
    private LevelTracker _levelTracker;
    private ThemeTracker _themeTracker;

    [Inject]
    private void Construct(SceneLoader sceneLoader, LevelTracker levelTracker, ThemeTracker themeTracker)
    {
        _sceneLoader = sceneLoader;
        _levelTracker = levelTracker;
        _themeTracker = themeTracker;
    }

    public override IEnumerator Run()
    {
        yield return new WaitForSeconds(0.5f);

        SetupGame();
        SetCurrentLevel();
        SetCurrentTheme();

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

    private void SetCurrentTheme()
    {
        _themeTracker.SetCurrentTheme(1); // <- From storage.
    }

    // The scene where the game begins.
    private void LoadStartScene()
    {
        _sceneLoader.LoadGameplay();
    }
}
