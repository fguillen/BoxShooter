using UnityEngine;

public class Spawner : MonoBehaviour
{
    float nextSpawnAt;
    MapManager mapManager;

    void Start()
    {
        mapManager = GameManager.instance.mapManager;
        SetNextSpawnAt();
    }

    void Update()
    {
        if(IsTimeForSpawn() && mapManager.CanSpawnEnemy())
            Spawn();
    }

    private void Spawn()
    {
        SetNextSpawnAt();
        GameObject enemyObject = Instantiate(mapManager.NextEnemy(), transform.position, Quaternion.identity);
        mapManager.EnemyAdded(enemyObject);
    }

    private bool IsTimeForSpawn()
    {
        return nextSpawnAt < Time.time;
    }

    void SetNextSpawnAt()
    {
        nextSpawnAt = Time.time + Random.Range(mapManager.data.spawnerMinWaitingTime, mapManager.data.spawnerMaxWaitingTime);
    }
}
