using System;
using UnityEngine;
using Zenject;

public abstract class Storage
{
    public abstract GameData GameData { get; protected set; }
    private DefaultGameData _defaultGameData;

    protected SDK SDK;

    [Inject]
    private void Construct(DefaultGameData defaultGameData, SDK SDK)
    {
        _defaultGameData = defaultGameData;
        this.SDK = SDK;
    }

    public abstract void Save();
    public abstract void Load(Action<bool> callback = null);

    public void DefaultData()
    {
        GameData = GameObject.Instantiate(_defaultGameData).GameData;
        Save();
    }

    public void SetAudioVolume(float volume)
    {
        GameData.AudioVolume = volume;
        Save();
    }

    public void SetLastCompletedLevel(int number)
    {
        GameData.LastCompletedLevel = number;
        Save();
    }

    public void SetCurrentTheme(int key)
    {
        GameData.CurrentTheme = key;
        Save();
    }

    public void AddUnlockedTheme(int key)
    {
        if (GameData.UnlockedThemes.Contains(key)) return;

        GameData.UnlockedThemes.Add(key);
        Save();
    }

    public void SetFirstEntry(bool value)
    {
        GameData.IsFirstEntry = value;
        Save();
    }
}
