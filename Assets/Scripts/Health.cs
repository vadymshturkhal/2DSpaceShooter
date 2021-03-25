using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Include methods
// SetRespawnPoint(Vector3 newRespawnPosition)
// InvicibilityCheck()
// Respawn()
// ReceiveDamage(int amount)
// ReceiveHealing(int amount)
// CheckDeath()
// Die()
// HandleDeathWithLives()
// HandleDeathWithoutLives()

public class Health : MonoBehaviour
{
    public int teamId = 0, defaultHealth = 3, currentHealth = 3, maximumHealth = 5; 
    [SerializeField]
    int currentLives = 3, maximumLives = 5;

    [SerializeField]
    float invincibilityTime = 3f;

    [SerializeField]
    bool isAlwaysInvincible = false, useLives = false;

    [SerializeField]
    GameObject deathEffect, hitEffect;

    float timeToBecomeDamagableAgain = 0;
    bool isInvincableFromDamage = false;
    Vector3 respawnPosition;

    void Start()
    {
        SetRespawnPoint(transform.position);
    }

    void FixedUpdate()
    {
        InvincibilityCheck();
    }

    void SetRespawnPoint(Vector3 newRespawnPosition)
    {
        respawnPosition = newRespawnPosition;
    }

    void InvincibilityCheck()
    {
        if (timeToBecomeDamagableAgain <= Time.time)
        {
            isInvincableFromDamage = false;
        }
    }

    void Respawn()
    {
        transform.position = respawnPosition;
        currentHealth = defaultHealth;
    }

    public void ReceiveDamage(int amount)
    {
        //if (isInvincableFromDamage || isAlwaysInvincible)
        //{
        //    return;
        //}

        //if (hitEffect != null)
        //{
        //    Instantiate(hitEffect, transform.position, transform.rotation, null);
        //}

        //timeToBecomeDamagableAgain = Time.time + invincibilityTime;
        //isInvincableFromDamage = true;
        currentHealth -= amount;
        CheckDeath();
    }

    public void ReceiveHealing(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
        CheckDeath();
    }

    bool CheckDeath()
    {
        if (currentHealth <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    public void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation, null);
        }

        if (useLives)
        {
            HandleDeathWithLives();
        }
        else
        {
            HandleDeathWithoutLives();
        }
    }

    void HandleDeathWithLives()
    {
        currentLives -= 1;
        if (currentLives > 0)
        {
            Respawn();
        }
        else
        {
            //if (gameObject.tag == "Player" && GameManager.instance != null)
            //{
            //    GameManager.instance.GameOver();
            //}
            //if (gameObject.GetComponent<Enemy>() != null)
            //{
            //    gameObject.GetComponent<Enemy>().DoBeforeDestroy();
            //}
            Destroy(this.gameObject);
        }
    }

    void HandleDeathWithoutLives()
    {
        //if (gameObject.tag == "Player" && GameManager.instance != null)
        //{
        //    GameManager.instance.GameOver();
        //}
        //if (gameObject.GetComponent<Enemy>() != null)
        //{
        //    gameObject.GetComponent<Enemy>().DoBeforeDestroy();
        //}
        Destroy(this.gameObject);
    }
}
