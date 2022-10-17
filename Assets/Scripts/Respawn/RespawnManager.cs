using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RespawnManager : MonoBehaviour
{
    Agent agent;
    SpawnPoint currentSpawnPoint;
    public UnityEvent OnRespawn;

    public void Initialize(Agent agent)
    {
        this.agent = agent;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("SpawnPoint"))
            SetCurrentSpawnPoint(collider.gameObject.GetComponent<SpawnPoint>());
    }

    public void SetCurrentSpawnPoint(SpawnPoint spawnPoint)
    {
        currentSpawnPoint = spawnPoint;
    }

    public void Respawn()
    {
        agent.transform.position = currentSpawnPoint.transform.position;
        OnRespawn?.Invoke();
    }
}
