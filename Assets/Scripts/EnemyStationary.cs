using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStationary : MonoBehaviour
{
    protected ProjectileHandler projectileHandler;

    virtual protected void Awake()
    {
        GameObject projectile = transform.Find("ProjectileHandler").gameObject;
        projectileHandler = projectile.GetComponent<ProjectileHandler>();
    }

    virtual protected void Start()
    {
        projectileHandler.Fire(true);
    }

}
