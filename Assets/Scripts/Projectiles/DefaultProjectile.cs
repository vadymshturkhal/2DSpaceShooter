using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : MonoBehaviour
{
    public int teamId = 0;
    public int projectileDamage = 1;
    Health triggeredGameObjectHealth;

    void OnTriggerEnter2D(Collider2D collider)
    {
        triggeredGameObjectHealth = collider.gameObject.GetComponent<Health>();
        if (triggeredGameObjectHealth != null)
        {
            if (triggeredGameObjectHealth.teamId != teamId)
            {
                triggeredGameObjectHealth.TakePoints(projectileDamage);
                Destroy(gameObject);
            }
        }
    }
}
