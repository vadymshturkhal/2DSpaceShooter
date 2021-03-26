using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    //static Health invisibilityInvoker;
    //static UnityAction<int> invisibilityListener;

    //public static void AddInvisibilityInvoker(Health invoker)
    //{
    //    if (invisibilityInvoker == null)
    //    {
    //        Debug.Log("Invoker == null");
    //    }

    //    invisibilityInvoker = invoker;

    //    if (invisibilityListener != null)
    //    {
    //        invisibilityInvoker.AddInvisibilityListener(invisibilityListener);
    //    }

    //}

    //public static void AddInvisibilityListener(UnityAction<int> listener)
    //{
    //    if (invisibilityListener == null)
    //    {
    //        Debug.Log("Listener == null");
    //    }

    //    invisibilityListener = listener;

    //    if (invisibilityInvoker != null)
    //    {
    //        invisibilityInvoker.AddInvisibilityListener(invisibilityListener);
    //    }
    //}

    //static List<Health> invisibilityInvokers = new List<Health>();
    //static List<UnityAction<int>> invisibilityListeners = new List<UnityAction<int>>();

    //public static void AddInvisibilityInvoker(Health invoker)
    //{
    //    invisibilityInvokers.Add(invoker);

    //    foreach (UnityAction<int> listener in invisibilityListeners)
    //    {
    //        invoker.AddInvisibilityListener(listener);
    //    }
    //}

    //public static void AddInvisibilityListener(UnityAction<int> listener)
    //{
    //    invisibilityListeners.Add(listener);

    //    foreach (Health invoker in invisibilityInvokers)
    //    {
    //        invoker.AddInvisibilityListener(listener);
    //    }
    //}
}
