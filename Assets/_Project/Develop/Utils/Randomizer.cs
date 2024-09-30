using System.Collections.Generic;
using UnityEngine;

public static class Randomizer
{
    public static bool TryChance(float chance)
    {
        if (chance < 0 || chance > 1)
            throw new System.ArgumentOutOfRangeException($"Chance {chance} is outside the range (0; 1).");

        return Random.Range(0f, 1f) <= chance;
    }

    public static T GetRandomValue<T>(List<T> values)
    {
        if (values.Count == 0)
            throw new System.ArgumentException("The list of random values is empty.");

        int randomIndex = Random.Range(0, values.Count);
        return values[randomIndex];
    }
}
