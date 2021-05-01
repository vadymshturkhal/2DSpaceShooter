using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1f)]
    float projectileVolume = 0.5f;

    [SerializeField]
    [Range(0.06f, 1f)]
    float TimeBetweenProjectiles = 0.15f;

    [SerializeField]
    AudioClipName projectileSound;

    int teamId;
    float timeOut;
    bool firing;
    ProjectileSpawner[] projectileSpawners;

    void Awake()
    {
        teamId = transform.parent.GetComponent<Health>().teamId;
        timeOut = TimeBetweenProjectiles;

        projectileSpawners = new ProjectileSpawner[transform.childCount];

        int i = 0;
        foreach (Transform child in transform)
        {
            projectileSpawners[i] = child.GetComponent<ProjectileSpawner>();
            i++;
        }

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
            foreach (ProjectileSpawner projectile in projectileSpawners)
            {
                projectile.SpawnProjectile(teamId);
            }

            timeOut = TimeBetweenProjectiles;

            AudioManager.Play(projectileSound, projectileVolume);
        }
        else
        {
            timeOut -= Time.deltaTime;
        }
    }
}
