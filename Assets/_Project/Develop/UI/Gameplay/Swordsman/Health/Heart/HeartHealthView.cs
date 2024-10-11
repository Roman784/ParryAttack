using System.Collections.Generic;
using UnityEngine;

public class HeartHealthView : HealthView
{
    [SerializeField] private Heart _heartPrefab;
    [SerializeField] private Transform _heartsContainer;

    private List<Heart> _hearts = new();

    public override void CreateBar(int amount)
    {
        for (int i = 0; i < amount; i++)
            CreateHeart();
    }

    public override void UpdateBar(int amount)
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            Heart heart = _hearts[i];

            if (i < amount)
                heart.Repair();
            else
                heart.Spend();
        }
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartPrefab);
        newHeart.transform.SetParent(_heartsContainer);

        _hearts.Add(newHeart);
    }
}
