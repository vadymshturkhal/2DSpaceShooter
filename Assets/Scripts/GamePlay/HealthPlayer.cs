using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : Health
{
    const float MaxRedColor = 1;

    [SerializeField]
    int lives = 1;
    [SerializeField]
    int maximumLives = 5;
    int defaultHealthPoints;

    [SerializeField]
    float invincibilityTime = 3f;
    float colorRedIncrementStep;

    float red;
    float tempRed;
    float green;
    float blue;
    float alpha;

    bool isInvincableFromDamage = false;

    GameObject invisibilityEffect;
    GameOverEvent gameOverEvent;

    UnityAction gameOverListener;

    SpriteRenderer playerSpriteRenderer;

    Color defaultColor;

    void Start()
    {
        defaultHealthPoints = healthPoints;
        invisibilityEffect = transform.Find("Shield").gameObject;

        gameOverEvent = new GameOverEvent();
        EventManager.AddGameOverInvoker(this);

        InitRGB();
    }

    void Respawn()
    {
        healthPoints = defaultHealthPoints;
        ResetRedComponent();
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
        AudioManager.Play(explodeSound);
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

        IncrementRedComponent(colorRedIncrementStep);

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

    void InitRGB()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = playerSpriteRenderer.color;
        colorRedIncrementStep = (float)(MaxRedColor - playerSpriteRenderer.color.r) / defaultHealthPoints;

        red = playerSpriteRenderer.color.r;
        green = playerSpriteRenderer.color.g;
        blue = playerSpriteRenderer.color.b;
        alpha = playerSpriteRenderer.color.a;

        tempRed = red;
    }

    void IncrementRedComponent(float value)
    {
        tempRed += value;

        if (tempRed > MaxRedColor)
        {
            return;
        }

        playerSpriteRenderer.color = new Color(tempRed, green, blue, alpha);
    }

    void ResetRedComponent()
    {
        playerSpriteRenderer.color = defaultColor;
    }
}
