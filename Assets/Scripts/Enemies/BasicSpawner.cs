using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawner : MonoBehaviour
{
    protected int quantity = 1;

    protected Action onDestroyAction;

    public Action OnDestroyAction
    {
        set { onDestroyAction = value; }
    }

    protected void DoOnDestroyAction()
    {
        if (onDestroyAction != null)
        {
            onDestroyAction();
        }
    }
}
