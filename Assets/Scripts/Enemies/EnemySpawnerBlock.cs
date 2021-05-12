using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBlock : MonoBehaviour
{
    int totalSpawners = 0;

    void IncSpawnersCount()
    {
        totalSpawners++;
    }

    void PrintQuantity()
    {
        Debug.Log(totalSpawners);
    }
}
