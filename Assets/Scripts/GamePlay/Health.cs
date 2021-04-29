using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int teamId = 0;

    [SerializeField]
    protected int healthPoints = 5;

    public GameObject deathEffect;

    public AudioClipName explodeSound;
    public AudioClipName hitSound;

    public void AddPoints(int amount)
    {
        healthPoints += amount;
    }

    public virtual void TakePoints(int amount)
    {
        healthPoints -= amount;
        AudioManager.Play(hitSound);
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
        AudioManager.Play(explodeSound);
    }
}
