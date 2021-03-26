using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator anim;
    Timer timer;

    void Start()
    {
        anim = GetComponent<Animator>();
        float len = anim.GetCurrentAnimatorStateInfo(0).length;

        timer = gameObject.AddComponent<Timer>();
		timer.Duration = len;
		timer.Run();
    }
        
    void Update()
    {
        // Destroy the game object if the explosion has finished its animation
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
