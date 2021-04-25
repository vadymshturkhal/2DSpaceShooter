using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : Health
{
    int defaultHealthPoints;

    [SerializeField]
    int lives = 1;
    int maximumLives = 5;

    [SerializeField]
    float invincibilityTime = 3f;

    bool isInvincableFromDamage = false;

    GameObject invisibilityEffect;
    GameOverEvent gameOverEvent;
    UnityAction gameOverListener;

    void Start()
    {
        defaultHealthPoints = healthPoints;
        invisibilityEffect = transform.Find("Shield").gameObject;

        gameOverEvent = new GameOverEvent();
        EventManager.AddGameOverInvoker(this);
    }

    void Respawn()
    {
        healthPoints = defaultHealthPoints;
        StartCoroutine(InvisibilityCoroutine(invincibilityTime));
    }

    void Die()
    {
        gameOverEvent.Invoke();
        base.Die();
    }

    public override void TakePoints(int amount)
    {
        if (isInvincableFromDamage)
        {
            return;
        }

        base.TakePoints(amount);

        if (IsNotAnyHP())
        {
            lives -= 1;
            if (lives <= 0)
            {
                // Die();
                gameOverEvent.Invoke();
            }
            else
            {
                Respawn();
            }
        }
    }

    public void AddLives(int count)
    {
        int result = lives + count;

        if (result > maximumLives)
        {
            result = maximumLives;
        }

        lives = result;
    }

    IEnumerator InvisibilityCoroutine(float duration)
    {
        isInvincableFromDamage = true;
        invisibilityEffect.SetActive(true);

        yield return new WaitForSeconds(duration);

        invisibilityEffect.SetActive(false);
        isInvincableFromDamage = false;
    }


    public void AddGameOverListener(UnityAction listener)
    {
        gameOverListener = listener;
        gameOverEvent.AddListener(listener);
    }
}
