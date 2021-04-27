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

    void DestroyAfterAnim()
    {
        if (deathEffect == null)
        {
            return;
        }

        deathEffect = Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
        Animator anim = deathEffect.GetComponent<Animator>();
        float len = anim.GetCurrentAnimatorStateInfo(0).length;

        TimerDelegate timerDelegate = GameObject.FindGameObjectWithTag("TimerDelegate").GetComponent<TimerDelegate>();
        timerDelegate.InitializeTimer(len, Destruct);
        gameObject.SetActive(false);
    }

    void Destruct()
    {
        gameOverEvent.Invoke();
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
                DestroyAfterAnim();
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
