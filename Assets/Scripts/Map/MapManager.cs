using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] public MapData data;
    public List<GameObject> enemiesInScene = new List<GameObject>();
    int enemiesNextIndex = 0;

    public void EnemyAdded(GameObject enemyObject)
    {
        enemiesInScene.Add(enemyObject);
        enemiesNextIndex ++;
    }

    public void EnemyRemoved(GameObject enemyObject)
    {
        enemiesInScene.Remove(enemyObject);
    }

    public GameObject NextEnemy()
    {
        GameObject nextEnemy = data.enemies[enemiesNextIndex];
        return nextEnemy;
    }

    public bool CanSpawnEnemy()
    {
        if(
            (enemiesInScene.Count < data.maxEnemiesInScene) &&
            (enemiesNextIndex < data.enemies.Count)
        )
            return true;
        else
            return false;
    }
}
