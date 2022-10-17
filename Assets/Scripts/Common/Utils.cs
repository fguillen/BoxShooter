using UnityEngine;

public static class Utils
{
    public static bool InLayerMask(int layer, LayerMask layerMask)
    {
        return layerMask == (layerMask | (1 << layer));
    }
}
