using System.Collections.Generic;
using UnityEngine;

public static class Randomizer
{
    public static bool TryProbability(float probability)
    {
        if (probability < 0 || probability > 1)
            throw new System.ArgumentOutOfRangeException($"Probability {probability} is outside the range (0; 1).");

        return Random.Range(0f, 1f) <= probability;
    }

    public static T GetRandomValue<T>(List<T> values)
    {
        if (values.Count == 0)
            throw new System.ArgumentException("The list of random values is empty.");

        int randomIndex = Random.Range(0, values.Count);
        return values[randomIndex];
    }
}
