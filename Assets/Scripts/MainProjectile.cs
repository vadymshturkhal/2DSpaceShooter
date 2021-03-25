using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProjectile : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
