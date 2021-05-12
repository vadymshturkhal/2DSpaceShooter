using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBlock : MonoBehaviour
{
    int totalSpawners = 0;

    Action onDestroyAction;

    public Action OnDestroyAction
    {
        set { onDestroyAction = value; }
    }

    void Start()
    {
        totalSpawners = transform.childCount;

        AddOnDestroyCallbackToChild();
    }

    void GameManagerCallback()
    {
        totalSpawners--;

        if (totalSpawners <= 0)
        {
            DoOnDestroyAction();
        }
    }

    void AddOnDestroyCallbackToChild()
    {
        foreach (Transform transform in transform)
        {
            transform.gameObject.GetComponent<EnemySpawner>().OnDestroyAction = GameManagerCallback;
        }
    }

    void DoOnDestroyAction()
    {
        if (onDestroyAction != null)
        {
            onDestroyAction();
            Destroy(gameObject);
        }
    }
}
