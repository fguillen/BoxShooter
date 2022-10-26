using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CenterObjectsInCellEditor : Editor
{
    [MenuItem("BoxShooter/CenterObjects", false, 100)]
    static void CenterObjects()
    {
        Debug.Log("CenterObjects()");
        // GameObject map = GameObject.Find("Map");



        CenterInCell[] components = GameObject.FindObjectsOfType<CenterInCell>();

        foreach (var component in components)
        {
            component.Center();
        }
    }
}
