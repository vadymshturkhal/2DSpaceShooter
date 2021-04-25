using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator anim;
    TimerDelegate timerDelegate;

    void Start()
    {
        anim = GetComponent<Animator>();
        float len = anim.GetCurrentAnimatorStateInfo(0).length;

        timerDelegate = GameObject.FindGameObjectWithTag("TimerDelegate").GetComponent<TimerDelegate>();
        timerDelegate.InitializeTimer(len, Destruct);
    }

    void Destruct()
    {
        Destroy(gameObject);
    }
}
