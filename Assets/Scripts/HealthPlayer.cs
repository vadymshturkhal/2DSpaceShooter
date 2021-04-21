using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        defaultHealthPoints = healthPoints;
        invisibilityEffect = transform.Find("Shield").gameObject;
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
                Die();
            }
            else
            {
                Respawn();
            }
        }
    }

    void Respawn()
    {
        healthPoints = defaultHealthPoints;
        StartCoroutine(InvisibilityCoroutine(invincibilityTime));
    }

    IEnumerator InvisibilityCoroutine(float duration)
    {
        isInvincableFromDamage = true;
        invisibilityEffect.SetActive(true);

        yield return new WaitForSeconds(duration);

        invisibilityEffect.SetActive(false);
        isInvincableFromDamage = false;
    }

    void Die()
    {
        base.Die();

        // #if UNITY_EDITOR
        //     UnityEditor.EditorApplication.isPlaying = false;
        // #elif UNITY_WEBPLAYER
        //     Application.OpenURL(webplayerQuitURL);
        // #else
        //     Application.Quit();
        // #endif
    }
}
