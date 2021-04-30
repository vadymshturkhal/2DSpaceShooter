using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int teamId = 0;

    [SerializeField]
    protected int healthPoints = 5;
    protected float hitStep; 

    public GameObject deathEffect;

    public AudioClipName explodeSound;
    public AudioClipName hitSound;

    protected SpriteRenderer spriteRenderer;

    protected void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        hitStep = HitEffectIncRed.CalculateIncStep(spriteRenderer, healthPoints);
    }

    public void AddPoints(int amount)
    {
        healthPoints += amount;
    }

    public virtual void TakePoints(int amount)
    {
        healthPoints -= amount;
        HitEffectIncRed.IncrementRedComponent(spriteRenderer, hitStep);
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
