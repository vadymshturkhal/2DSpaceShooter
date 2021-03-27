using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotational : EnemyStationary
{
    const float epsilon = 0.1f;

    [SerializeField]
    [Range(10, 100)]
    int rotationalSpeed = 10;
    float currentSpeed;
    float angleBetweenEnemyAndTarget;

    Vector3 position;
    Vector3 difference;
    GameObject currentTarget;

    protected override void Awake()
    {
        currentTarget = GameObject.FindGameObjectWithTag("Player");
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        projectileHandler.Fire(true);
    }

    void FixedUpdate()
    {
        RotateToEnemy();
    }

    // Uses angle
    // Uses tricks like -transform.up and Abs <= epsilon * speed
    virtual protected void RotateToEnemy()
    {
        if (currentTarget == null)
        {
            return;
        }

        position = currentTarget.transform.position - transform.position;
        position = position.normalized;
        
        angleBetweenEnemyAndTarget = Vector3.SignedAngle(position, -transform.up, Vector3.forward);

        if (Mathf.Abs(angleBetweenEnemyAndTarget) <= epsilon * rotationalSpeed)
        {
            return;
        }

        if (angleBetweenEnemyAndTarget > 0)
        {
            StartRotation(true);
        }
        else
        {
            StartRotation(false);
        }
    }

    void StartRotation(bool onTheRight)
    {
        if (onTheRight)
        {
            transform.rotation = Quaternion.AngleAxis(currentSpeed, Vector3.forward);
            currentSpeed -= Time.deltaTime * rotationalSpeed;
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(currentSpeed, Vector3.forward);
            currentSpeed += Time.deltaTime * rotationalSpeed;
        }
    }
}
