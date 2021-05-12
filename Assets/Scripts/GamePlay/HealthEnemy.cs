using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthEnemy : Health
{
    [SerializeField]
    int score = 0;

    AddScoreEvent addScoreEvent;

    Action onDestroyAction;

    public Action OnDestroyAction
    {
        set { onDestroyAction = value; }
    }

    new void Start()
    {
        score = gameObject.GetComponent<EnemyStationary>().scoreValue;
        addScoreEvent = new AddScoreEvent();
        EventManager.AddScoreInvoker(this);

        base.Start();
    }

    public override void TakePoints(int amount)
    {
        base.TakePoints(amount);

        if (IsNotAnyHP())
        {
            if (onDestroyAction != null)
            {
                onDestroyAction();
            }

            DieWithEvent();
        }
    }

    void DieWithEvent()
    {
        addScoreEvent.Invoke(score);
        Die();
    }

    public void AddScoreEventListener(UnityAction<int> listener)
    {
        addScoreEvent.AddListener(listener);
    }
}
