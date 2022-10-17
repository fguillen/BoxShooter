using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"SpawnPoint.Trigger({collider.gameObject.tag})");
    }
}
