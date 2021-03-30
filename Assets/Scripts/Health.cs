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
    public int teamId = 0, defaultHealth = 3, currentHealth = 3, maximumHealth = 5;
    [SerializeField]
    int currentLives = 3, maximumLives = 5, score = 0;

    [SerializeField]
    float invincibilityTime = 3f;
    float timeToBecomeDamagableAgain = 0;

    [SerializeField]
    bool useLives = false;
    bool isInvincableFromDamage = false;
    bool isEnemy = false;

    [SerializeField]
    GameObject deathEffect, hitEffect, invisibilityEffect;
    GameObject invisibility;
    Vector3 respawnPosition;
    UnityAction<int> addScoreListener;
    AddScoreEvent addScoreEvent;

    void Awake()
    {
        if (gameObject.GetComponent<EnemyStationary>() != null)
        {
            isEnemy = true;
            score = gameObject.GetComponent<EnemyStationary>().scoreValue;
            addScoreEvent = new AddScoreEvent();
            EventManager.AddScoreInvoker(this);
        }
    }

    IEnumerator InvisibilityCoroutine(float duration)
    {
        isInvincableFromDamage = true;
        invisibility = Instantiate(invisibilityEffect, transform.position, Quaternion.identity);
        invisibility.transform.SetParent(gameObject.transform, true);

        yield return new WaitForSeconds(duration);

        Destroy(invisibility);
        isInvincableFromDamage = false;
    }

    void SetRespawnPoint(Vector3 newRespawnPosition)
    {
        respawnPosition = newRespawnPosition;
    }

    void Respawn()
    {
        transform.position = respawnPosition;
        currentHealth = defaultHealth;
        timeToBecomeDamagableAgain = Time.time + invincibilityTime;
        isInvincableFromDamage = true;
    }

    public void ReceiveDamage(int amount)
    {
        if (isInvincableFromDamage)
        {
            return;
        }

        currentHealth -= amount;
        CheckDeath();
    }

    void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation, null);
        }

        HandleDeathWithLives(useLives);
    }

    void HandleDeathWithLives(bool lives)
    {
        if (lives)
        {
            currentLives -= 1;
            if (currentLives > 0)
            {
                Respawn();
                StartCoroutine(InvisibilityCoroutine(invincibilityTime));
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (isEnemy)
            {
                addScoreEvent.Invoke(score);
                addScoreEvent.RemoveListener(addScoreListener);
            }
            Destroy(gameObject);
        }
    }

    public void AddScoreEventListener(UnityAction<int> listener)
    {
        addScoreListener = listener;
        addScoreEvent.AddListener(listener);
    }
}
