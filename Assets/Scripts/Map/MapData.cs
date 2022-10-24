using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMapData", menuName = "Map/New Map")]
public class MapData : ScriptableObject
{
    public List<GameObject> enemies;
    public int maxEnemiesInScene = 5;
    public float spawnerMinWaitingTime = 2f;
    public float spawnerMaxWaitingTime = 10f;
}
