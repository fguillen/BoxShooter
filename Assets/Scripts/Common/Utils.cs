using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static bool RandomChance(float chances)
    {
        return (Random.Range(0f, 1f) <= chances);
    }

    public static T RandomElement<T>(List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
}
