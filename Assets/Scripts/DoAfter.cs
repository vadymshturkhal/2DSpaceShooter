using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAfter : MonoBehaviour
{
    int partyCounter;

    [SerializeField]
    List<GameObject> party;

    [SerializeField]
    List<GameObject> doActive;

    [SerializeField]
    // GameObject gameManager;
    // GameManager GM;

    void Start()
    {
        foreach (GameObject gameObj in party)
        {
            gameObj.AddComponent<DoAfterSupporter>().SetAction = ReduceParty;
        }

        partyCounter = party.Count;

        // GM = gameManager.GetComponent<GameManager>();

        // DoActive(false);
    }

    void ReduceParty()
    {
        partyCounter--;
        if (partyCounter <= 0)
        {
            DoAfterEvent();
        }
    }

    void DoAfterEvent()
    {
        DoActive(true);
        Destroy(gameObject);
    }

    void DoActive(bool state)
    {
        foreach (GameObject gameObj in doActive)
        {
            gameObj.SetActive(state);
        }
    }
}
