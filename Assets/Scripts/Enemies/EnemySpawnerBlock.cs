using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBlock : BasicSpawner
{
    void Start()
    {
        quantity = transform.childCount;

        AddOnDestroyCallbackToChild();
    }

    void GameManagerCallback()
    {
        quantity--;

        if (quantity <= 0)
        {
            DoOnDestroyAction();
            Destroy(gameObject);
        }
    }

    void AddOnDestroyCallbackToChild()
    {
        foreach (Transform transform in transform)
        {
            transform.gameObject.GetComponent<EnemySpawner>().OnDestroyAction = GameManagerCallback;
        }
    }
}
