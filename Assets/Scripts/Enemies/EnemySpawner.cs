using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    const bool AddEnemy = true;

    [SerializeField]
    int quantityForSpawn = 1;

    [SerializeField]
    float timeBetweenSpawn = 1;

    [SerializeField]
    GameObject enemy;

    TimerDelegate timer;

    Action onDestroyAction;

    public Action OnDestroyAction
    {
        set { onDestroyAction = value; }
    }

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

        for (int i = 0; i < quantityForSpawn; i++)
        {
            timer.InitializeTimer(tempTime, SpawnEnemy);
            tempTime += timeBetweenSpawn;
        }
    }

    void ReduceQuantityOfEnemies()
    {
        quantityForSpawn--;

        if (quantityForSpawn <= 0)
        {
            if (onDestroyAction != null)
            {
                DoOnDestroyAction();
            }

            Destroy(gameObject);
        }
    }

    void DoOnDestroyAction()
    {
        if (onDestroyAction != null)
        {
            onDestroyAction();
        }
    }
}
