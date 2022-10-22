using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    int numEnemies = 0;

    public void EnemyAdded(Agent agent)
    {
        numEnemies ++;
    }
}
