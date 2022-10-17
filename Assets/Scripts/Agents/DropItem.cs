using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform objectTransform;

    public void Drop()
    {
        Instantiate(prefab, objectTransform.position, Quaternion.identity);
    }
}
