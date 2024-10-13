using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class BootEntryPoint : EntryPoint
{
    private SceneLoader _sceneLoader;
    private Storage _storage;
    private LevelTracker _levelTracker;
    private ThemeTracker _themeTracker;

    [Inject]
    private void Construct(SceneLoader sceneLoader, Storage storage, LevelTracker levelTracker, ThemeTracker themeTracker)
    {
        _sceneLoader = sceneLoader;
        _storage = storage;
        _levelTracker = levelTracker;
        _themeTracker = themeTracker;
    }

    public override IEnumerator Run()
    {
        SetupGame();

        yield return LoadData();

        SetCurrentLevel();
        SetCurrentTheme();

        LoadStartScene();
    }

    private IEnumerator LoadData()
    {
        bool isLoaded = false;

        _storage.Load((res) => 
        {
            if (!res)
                _storage.DefaultData();

            isLoaded = true;
        });

        yield return new WaitUntil(() => isLoaded);
    }

    private void SetupGame()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void SetCurrentLevel()
    {
        int number = _storage.GameData.LastLevel;
        _levelTracker.SetCurrentLevelNumber(number);
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
