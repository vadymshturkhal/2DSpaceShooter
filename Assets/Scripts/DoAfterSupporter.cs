using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAfterSupporter : MonoBehaviour
{
    Action callback;

    public Action SetAction
    {
        set { callback = value; }
    }

    void OnDestroy()
    {
        if (callback != null)
        {
            callback();
        }
    }
}
