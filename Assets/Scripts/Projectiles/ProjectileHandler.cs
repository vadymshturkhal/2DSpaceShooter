using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    [SerializeField]
    [Range(0.15f, 1f)]
    float TimeBetweenProjectiles = 0.15f;

    [SerializeField]
    AudioClipName projectileSound;

    int teamId;
    float timeOut;
    bool firing;
    ProjectileSpawner projectileSpawner;

    void Awake()
    {
        teamId = transform.parent.GetComponent<Health>().teamId;
        timeOut = TimeBetweenProjectiles;
    }

    void FixedUpdate()
    {
        if (firing)
        {
            Firing();
        }
    }

    public void Fire(bool firing)
    {
        // If pressed once we fire
        Firing();
        this.firing = firing;
    }

    void Firing()
    {
        if (timeOut <= 0)
        {
            foreach (Transform child in transform)
            {
                projectileSpawner = child.GetComponent<ProjectileSpawner>();
                projectileSpawner.SpawnProjectile(teamId);
            }

            timeOut = TimeBetweenProjectiles;

            AudioManager.Play(projectileSound);
        }
        else
        {
            timeOut -= Time.deltaTime;
        }
    }
}
