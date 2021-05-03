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

    // Start is called before the first frame update
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
            Instantiate(enemy, transform.position, transform.rotation).gameObject.transform.SetParent(gameObject.transform);
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

    public void ReduceQuantityOfEnemies()
    {
        quantityForSpawn -= 1;
        gameManager.EnemyController(!AddEnemy, 1);

        if (quantityForSpawn <= 0)
        {
            Destroy(gameObject);
            return;
        }

    }
}
