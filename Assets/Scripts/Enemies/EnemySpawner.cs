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

    GameManager gameManager;

    TimerDelegate timer;

    void Start()
    {
        timer = gameObject.GetComponent<TimerDelegate>();
        if (timer == null)
        {
            timer = gameObject.AddComponent<TimerDelegate>();
        }

        SpawnEnemies();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.EnemyController(AddEnemy, quantityForSpawn);
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
        
        gameManager.EnemyController(!AddEnemy, 1);

        if (quantityForSpawn <= 0)
        {
            Destroy(gameObject);
        }
    }
}
