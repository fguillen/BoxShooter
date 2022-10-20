using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnerData", menuName = "Map/New Spawner")]
public class SpawnerData : ScriptableObject
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public float minWaitingTime = 2f;
    [SerializeField] public float maxWaitingTime = 10f;
}
