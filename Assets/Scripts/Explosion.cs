using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        DestroyAfterAnim();
    }

    void DestroyAfterAnim()
    {
        Animator anim = GetComponent<Animator>();
        float len = anim.GetCurrentAnimatorStateInfo(0).length;

        TimerDelegate timerDelegate = GameObject.FindGameObjectWithTag("TimerDelegate").GetComponent<TimerDelegate>();
        timerDelegate.InitializeTimer(len, Destruct);
    }

    void Destruct()
    {
        Destroy(gameObject);
    }
}
