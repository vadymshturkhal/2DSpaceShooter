using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    const float ProjectileSpeed = 10f;

    [SerializeField]
    GameObject projectile;
    GameObject currentProjectile;

    void Awake()
    {
        if (projectile == null)
        {
            projectile = Resources.Load<GameObject>("Prefabs/Projectiles/ProjectileEx1");
        }

        SpawnProjectile();
    }

    public void SpawnProjectile()
    {
        currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        currentProjectile.transform.up = transform.up;
        currentProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * ProjectileSpeed, ForceMode2D.Impulse);

    }
}
