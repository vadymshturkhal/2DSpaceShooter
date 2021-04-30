using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthEnemy : Health
{
    [SerializeField]
    int score = 0;

    AddScoreEvent addScoreEvent;
    UnityAction<int> addScoreListener;
    GameObject parent;

    new void Start()
    {
        score = gameObject.GetComponent<EnemyStationary>().scoreValue;
        addScoreEvent = new AddScoreEvent();
        EventManager.AddScoreInvoker(this);

        parent = gameObject.transform.parent.gameObject;

        base.Start();
    }

    public override void TakePoints(int amount)
    {
        base.TakePoints(amount);

        if (IsNotAnyHP())
        {
            if (parent != null)
            {
                parent.GetComponent<EnemySpawner>().ReduceQuantityOfEnemies();
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
        addScoreListener = listener;
        addScoreEvent.AddListener(listener);
    }
}
