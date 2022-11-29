using UnityEngine;

public static class LayerUtils
{
    public static LayerMask Add(LayerMask layerMaskA, LayerMask layerMaskB)
    {
        return layerMaskA | layerMaskB;
    }

    public static bool InLayerMask(int layer, LayerMask layerMask)
    {
        return layerMask == (layerMask | (1 << layer));
    }
}
