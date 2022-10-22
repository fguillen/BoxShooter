using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBreakable", menuName = "Map/New Breakable")]
public class BreakableData : ScriptableObject
{
    [SerializeField] public List<Sprite> sprites;
    [SerializeField] public List<Color> spriteColors = new List<Color>();
    [SerializeField] public List<GameObject> pickablePrefabs = new List<GameObject>();
    [SerializeField][Range(0f, 1f)] public float pickableChance;
}
