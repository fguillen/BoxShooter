using System;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static Transform FindRecursive(this Transform self, string exactName) => self.FindRecursive(child => child.name == exactName);

    public static Transform FindRecursive(this Transform self, Func<Transform, bool> selector)
    {
        foreach (Transform child in self)
        {
            if (selector(child))
                return child;

            var finding = child.FindRecursive(selector);

            if (finding != null)
                return finding;
        }

        return null;
    }

    // public static List<T> GetComponentsInChildrenRecursively<T>(this Transform self, List<T> result)
    // {
    //     foreach (Transform child in self)
    //     {
    //         T[] components = child.GetComponents<T>();

    //         foreach (T component in components)
    //             if (component != null)
    //                 result.Add(component);

    //         GetComponentsInChildrenRecursively<T>(child, result);
    //     }

    //     return result;
    // }
}
