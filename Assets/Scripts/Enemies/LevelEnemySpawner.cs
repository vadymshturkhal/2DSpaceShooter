using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnemySpawner : BasicSpawner
{
    [SerializeField]
    GameObject gameManager;

    GameManager GM;

    void Start()
    {
        quantity = transform.childCount;

        GM = gameManager.GetComponent<GameManager>();

        AddOnDestroyCallbackToChild();
    }

    void OnDestroyEnemySpawnerBlock()
    {
        quantity--;

        if (quantity <= 0)
        {
            print("Victory");
            GM.ShowVictoryScreen();
        }
        else
        {
            DoOnDestroyAction();
        }
    }

    void AddOnDestroyCallbackToChild()
    {
        foreach (Transform transform in transform)
        {
            transform.gameObject.GetComponent<EnemySpawnerBlock>().OnDestroyAction = OnDestroyEnemySpawnerBlock;
        }
    }
}
