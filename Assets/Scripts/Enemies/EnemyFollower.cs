using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 5f)]
    float moveSpeed = 0.2f;
    [SerializeField]
    [Range(1f, 3f)]
    float minDistanceToTarget = 1f;
    float step;


    [SerializeField]
    GameObject target;

    Vector3 from;
    Vector3 to;

    void Awake()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void FixedUpdate()
    {
        MoveToward();
    }

    void MoveToward()
    {
        if (target == null)
        {
            return;
        }

        step = moveSpeed * Time.deltaTime;
        from = gameObject.transform.position;
        to = target.transform.position;

        if (Vector3.Distance(from, to) <= minDistanceToTarget)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(from, to, step);
    }
}
