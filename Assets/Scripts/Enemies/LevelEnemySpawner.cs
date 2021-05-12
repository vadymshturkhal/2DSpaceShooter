using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject gameManager;

    GameManager GM;

    void Start()
    {
        GM = gameManager.GetComponent<GameManager>();
        // enemiesQuantity = 
        // Debug.Log(enemiesQuantity);
    }
}
