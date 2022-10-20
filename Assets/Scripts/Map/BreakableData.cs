using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBreakable", menuName = "Map/New Breakable")]
public class BreakableData : ScriptableObject
{
    [SerializeField] public List<Sprite> sprites;
}
