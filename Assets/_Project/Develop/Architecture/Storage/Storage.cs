using System;
using UnityEngine;
using Zenject;

public abstract class Storage
{
    public abstract GameData GameData { get; protected set; }
    private DefaultGameData _defaultGameData;

    [Inject]
    private void Construct(DefaultGameData defaultGameData)
    {
        _defaultGameData = defaultGameData;
    }

    public abstract void Save();
    public abstract void Load(Action<bool> callback = null);

    public void DefaultData()
    {
        GameData = GameObject.Instantiate(_defaultGameData).GameData;
        Save();
    }

    public void SetLastLevel(int number)
    {
        GameData.LastLevel = number;
        Save();
    }
}
