using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDelegate : MonoBehaviour
{
    public void InitializeTimer(float sec, Action callback)
    {
        StartCoroutine(TimerCoroutine(sec, callback));
    }

    IEnumerator TimerCoroutine(float duration, Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback();
    }
}
