using System.Collections;
using UnityEngine;
using UnityEngine.Events;

// Include methods
// InvisibilityCoroutine(float duration)
// SetRespawnPoint(Vector3 newRespawnPosition)
// Respawn()
// ReceiveDamage(int amount)
// CheckDeath()
// Die()
// HandleDeathWithLives()

public class Health : MonoBehaviour
{
    public int teamId = 0;

    [SerializeField]
    protected int healthPoints = 5;

    public GameObject deathEffect;
    public GameObject hitEffect;

    public void AddPoints(int amount)
    {
        healthPoints += amount;
    }

    public virtual void TakePoints(int amount)
    {
        healthPoints -= amount;

        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, transform.rotation, null);
        }
    }

    protected virtual bool IsNotAnyHP()
    {
        if (healthPoints <= 0)
        {
            return true;
        }
        return false;
    }

    protected virtual void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation, null);
        }
        Destroy(gameObject);
    }
}
