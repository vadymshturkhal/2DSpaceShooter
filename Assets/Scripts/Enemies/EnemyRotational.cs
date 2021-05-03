using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotational : EnemyStationary
{
    const float epsilon = 0.02f;

    [SerializeField]
    [Range(10, 100)]
    int rotationalSpeed = 10;
    float angleBetweenEnemyAndTarget;

    Vector3 position;
    Vector3 tempVector;
    GameObject currentTarget;

    protected override void Awake()
    {
        currentTarget = GameObject.FindGameObjectWithTag("Player");
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected void FixedUpdate()
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
            tempVector = transform.position;
            tempVector.z += rotationalSpeed * Time.deltaTime;
            gameObject.transform.Rotate(0, 0, -tempVector.z, Space.World);
        }
        else
        {
            tempVector = transform.position;
            tempVector.z += rotationalSpeed * Time.deltaTime;
            gameObject.transform.Rotate(0, 0, tempVector.z, Space.World);
        }
    }
}
