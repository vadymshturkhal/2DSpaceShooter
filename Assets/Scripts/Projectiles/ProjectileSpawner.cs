using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [Range(5f, 30f)]
    [SerializeField]
    float ProjectileSpeed = 10f;

    [SerializeField]
    GameObject projectile;
    GameObject currentProjectile;

    void Awake()
    {
        if (projectile == null)
        {
            projectile = Resources.Load<GameObject>("Prefabs/Projectiles/DefaultProjectile");
        }
    }

    // FIXME Set projectile as a child but without changing coordinate system
    public void SpawnProjectile(int teamId)
    {
        currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        currentProjectile.transform.up = transform.up;
        currentProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * ProjectileSpeed, ForceMode2D.Impulse);
        currentProjectile.GetComponent<DefaultProjectile>().teamId = teamId;
    }
}
