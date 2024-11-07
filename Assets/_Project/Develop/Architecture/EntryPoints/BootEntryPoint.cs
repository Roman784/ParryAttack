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
    private SDK _SDK;
    private Translator _translator;

    [Inject]
    private void Construct(SceneLoader sceneLoader, Storage storage, AudioPlayer audioPlayer, 
                           LevelTracker levelTracker, ThemeTracker themeTracker, SDK SDK, Translator translator)
    {
        _sceneLoader = sceneLoader;
        _storage = storage;
        _audioPlayer = audioPlayer;
        _levelTracker = levelTracker;
        _themeTracker = themeTracker;
        _SDK = SDK;
        _translator = translator;
    }

    private void Start()
    {
        Coroutines.StartRoutine(Run());
    }

    public override IEnumerator Run()
    {
        SetupGame();

        yield return InitSDK();
        yield return LoadData();

        InitTranslator();
        InitAudioPlayer();
        SetCurrentLevel();
        SetCurrentTheme();
        StartBackgroundMusci();

        LoadStartScene();
    }

    private IEnumerator InitSDK()
    {
        bool isInited = false;

        _SDK.Init((res) =>
        {
            isInited = res;
        });

        yield return new WaitUntil(() => isInited);
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

    private void InitTranslator()
    {
        Language language = _SDK.GetLanguage();
        _translator.SetaLanguage(language);
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
        _SDK.GameReady();
        _sceneLoader.LoadGameplay();
    }
}
