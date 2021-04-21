using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static Queue<HealthEnemy> addScoreInvokers = new Queue<HealthEnemy>();
    static UnityAction<int> addScoreListener;

    public static void AddScoreInvoker(HealthEnemy invoker)
    {
        addScoreInvokers.Enqueue(invoker);

        if (addScoreListener != null)
        {
            while (addScoreInvokers.Count != 0)
            {
                addScoreInvokers.Dequeue().AddScoreEventListener(addScoreListener);
            }
        }
    }

    public static void AddScoreListener(UnityAction <int> listener)
    {
        addScoreListener = listener;
        while (addScoreInvokers.Count != 0)
        {
            addScoreInvokers.Dequeue().AddScoreEventListener(addScoreListener);
        }
    }


    static HealthPlayer gameOverInvoker;
    static UnityAction gameOverListener;

    public static void AddGameOverInvoker(HealthPlayer invoker)
    {
        gameOverInvoker = invoker;

        if (gameOverListener != null)
        {
            gameOverInvoker.AddGameOverListener(gameOverListener);
        }
    }

    public static void AddGameOverListener(UnityAction listener)
    {
        gameOverListener = listener;

        if (gameOverInvoker != null)
        {
            gameOverInvoker.AddGameOverListener(gameOverListener);
        }

    }
}
