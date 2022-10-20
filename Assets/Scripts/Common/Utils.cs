using UnityEngine;

public static class Utils
{
    public static bool InLayerMask(int layer, LayerMask layerMask)
    {
        return layerMask == (layerMask | (1 << layer));
    }

    public static bool RandomChance(float chances)
    {
        return (Random.Range(0f, 1f) <= chances);
    }
}
