using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ProjectileHandler projectileHandler;

    void Awake()
    {
        GameObject projectile = transform.Find("ProjectileHandler").gameObject;
        projectileHandler = projectile.GetComponent<ProjectileHandler>();
    }

    void Start()
    {
        projectileHandler.Fire(true);
    }

}
