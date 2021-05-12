using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnemySpawner : MonoBehaviour
{
    int totalSpawnerBlocks = 0;

    [SerializeField]
    GameObject gameManager;

    GameManager GM;

    Action onDestroyAction;

    public Action OnDestroyAction
    {
        set { onDestroyAction = value; }
    }

    void Start()
    {
        totalSpawnerBlocks = transform.childCount;

        GM = gameManager.GetComponent<GameManager>();

        AddOnDestroyCallbackToChild();
    }

    void OnDestroyEnemySpawnerBlock()
    {
        totalSpawnerBlocks--;


        if (totalSpawnerBlocks <= 0)
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

    void DoOnDestroyAction()
    {
        if (onDestroyAction != null)
        {
            onDestroyAction();
        }
    }
}
