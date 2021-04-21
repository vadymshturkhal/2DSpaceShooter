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

    void Start()
    {
        score = gameObject.GetComponent<EnemyStationary>().scoreValue;
        addScoreEvent = new AddScoreEvent();
        EventManager.AddScoreInvoker(this);
    }

    public override void TakePoints(int amount)
    {
        base.TakePoints(amount);

        if (IsNotAnyHP())
        {
            Die();
        }
    }

    void Die()
    {
        addScoreEvent.Invoke(score);
        print(score);
        base.Die();
    }

    public void AddScoreEventListener(UnityAction<int> listener)
    {
        addScoreListener = listener;
        addScoreEvent.AddListener(listener);
    }
}
