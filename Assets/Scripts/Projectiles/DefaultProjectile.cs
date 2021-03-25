using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : MonoBehaviour
{
    public int teamId = 0;
    Health triggeredGameObjectHealth;

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        triggeredGameObjectHealth = collider.gameObject.GetComponent<Health>();
        if (triggeredGameObjectHealth != null)
        {
            if (triggeredGameObjectHealth.teamId != teamId)
            {
                triggeredGameObjectHealth.ReceiveDamage(1);
                Destroy(gameObject);
            }
        }
    }
}
