using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    int quantityForSpawn = 1;
    [SerializeField]
    float timeBetweenSpawn = 1;
    TimerDelegate timer;

    [SerializeField]
    GameObject enemy;

    // Start is called before the first frame update
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
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }

    void SpawnEnemies()
    {
        float tempTime = timeBetweenSpawn;

        for (int i = 0; i < quantityForSpawn; i++)
        {
            timer.InitializeTimer(tempTime, SpawnEnemy);
            tempTime += timeBetweenSpawn;
        }
    }
}
