using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwordsmanHealth : MonoBehaviour
{
    [SerializeField] private Heart _heartPrefab;
    [SerializeField] private Transform _heartsContainer;

    [HideInInspector] public UnityEvent OnAllHeartsSpent = new();

    private List<Heart> _hearts = new();

    public void Init(int heartsCount)
    {
        for (int i = 0; i < heartsCount; i++)
            CreateHeart();
    }

    private void CreateHeart()
    {
        Heart newHeart = Object.Instantiate(_heartPrefab, Vector3.zero, Quaternion.identity, _heartsContainer);
        _hearts.Add(newHeart);
    }

    public void SpendHeart()
    {
        for (int i = _hearts.Count-1; i >= 0; i--)
        {
            Heart heart = _hearts[i];

            if (heart.IsEmpty)
                continue;

            heart.Spend();
            break;
        }

        HandleFullHeartsCount();
    }

    private void HandleFullHeartsCount()
    {
        if (GetFullHeartsCount() == 0)
            OnAllHeartsSpent.Invoke();
    }

    private int GetFullHeartsCount() => GetHeartsCount(false);
    private int GetEmptyHeartsCount() => GetHeartsCount(true);

    private int GetHeartsCount(bool isEmpty)
    {
        int count = 0;
        foreach (var heart in _hearts)
        {
            if (heart.IsEmpty == isEmpty)
                count += 1;
        }

        return count;
    }
}
