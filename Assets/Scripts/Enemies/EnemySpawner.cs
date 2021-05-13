using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BasicSpawner
{
    const bool AddEnemy = true;

    [SerializeField]
    int quantityToSpawn = 1;

    [SerializeField]
    float timeBetweenSpawn = 1;

    [SerializeField]
    GameObject enemy;

    TimerDelegate timer;

    void Start()
    {
        timer = gameObject.GetComponent<TimerDelegate>();
        if (timer == null)
        {
            timer = gameObject.AddComponent<TimerDelegate>();
        }

        SpawnEnemies();
    }

    void SpawnEnemy()
    {
        if (enemy != null)
        {
            GameObject tempEnemy = Instantiate(enemy, transform.position, transform.rotation).gameObject;
            tempEnemy.transform.SetParent(gameObject.transform);
            tempEnemy.GetComponent<HealthEnemy>().OnDestroyAction = ReduceQuantityOfEnemies;
        }
    }

    void SpawnEnemies()
    {
        float tempTime = timeBetweenSpawn;

        for (int i = 0; i < quantityToSpawn; i++)
        {
            timer.InitializeTimer(tempTime, SpawnEnemy);
            tempTime += timeBetweenSpawn;
        }
    }

    void ReduceQuantityOfEnemies()
    {
        quantityToSpawn--;

        if (quantityToSpawn <= 0)
        {
            DoOnDestroyAction();
            Destroy(gameObject);
        }
    }
}
