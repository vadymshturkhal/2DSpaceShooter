using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    int quantityForSpawn = 1;
    [SerializeField]
    float timeBetweenEnemies = 1;
    TimerDelegate timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<TimerDelegate>();
        SpawnEnemies();
    }

    void SpawnEnemy()
    {
        print("Spawn Enemy");
    }

    void SpawnEnemies()
    {
        float tempTime = timeBetweenEnemies;

        for (int i = 0; i < quantityForSpawn; i++)
        {
            timer.InitializeTimer(tempTime, SpawnEnemy);
            tempTime += timeBetweenEnemies;
        }
    }
}
