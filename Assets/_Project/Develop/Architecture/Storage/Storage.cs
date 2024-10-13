using System;
using UnityEngine;
using Zenject;

public abstract class Storage
{
    public abstract GameData GameData { get; protected set; }

    [Inject]
    private void Construct()
    {
    }

    public abstract void Save();
    public abstract void Load(Action<bool> callback = null);

    public void DefaultData()
    {
        Debug.Log("Default data");
    }
}
