using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] SpawnerData data;
    float nextSpawnAt;

    void Start()
    {
        SetNextSpawnAt();
    }

    void Update()
    {
        if(IsTimeForSpawn())
            Spawn();
    }

    private void Spawn()
    {
        SetNextSpawnAt();
        Instantiate(data.enemyPrefab, transform.position, Quaternion.identity);
    }

    private bool IsTimeForSpawn()
    {
        return nextSpawnAt < Time.time;
    }

    void SetNextSpawnAt()
    {
        nextSpawnAt = Time.time + Random.Range(data.minWaitingTime, data.maxWaitingTime);
    }
}
