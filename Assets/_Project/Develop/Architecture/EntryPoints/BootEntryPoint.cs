using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class BootEntryPoint : EntryPoint
{
    private SceneLoader _sceneLoader;
    private Storage _storage;
    private AudioPlayer _audioPlayer;
    private LevelTracker _levelTracker;
    private ThemeTracker _themeTracker;

    [Inject]
    private void Construct(SceneLoader sceneLoader, Storage storage, AudioPlayer audioPlayer, 
                           LevelTracker levelTracker, ThemeTracker themeTracker)
    {
        _sceneLoader = sceneLoader;
        _storage = storage;
        _audioPlayer = audioPlayer;
        _levelTracker = levelTracker;
        _themeTracker = themeTracker;
    }

    public override IEnumerator Run()
    {
        Debug.Log("Start boot");
        SetupGame();

        yield return LoadData();

        InitAudioPlayer();
        SetCurrentLevel();
        SetCurrentTheme();
        StartBackgroundMusci();

        LoadStartScene();
        Debug.Log("end boot");
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
    }

    private void InitAudioPlayer()
    {
        float volume = _storage.GameData.AudioVolume;
        _audioPlayer.Init(volume);
    }

    private void SetCurrentLevel()
    {
        int number = _storage.GameData.LastCompletedLevel + 1;
        _levelTracker.SetCurrentLevelNumber(number);
    }

    private void SetCurrentTheme()
    {
        int key = _storage.GameData.CurrentTheme;
        _themeTracker.SetCurrentTheme(key);
    }

    private void StartBackgroundMusci()
    {
        _audioPlayer.BackgroundMusic.Start();
    }

    // The scene where the game begins.
    private void LoadStartScene()
    {
        _sceneLoader.LoadGameplay();
    }
}
