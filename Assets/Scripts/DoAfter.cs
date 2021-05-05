using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAfter : MonoBehaviour
{
    int partyCounter;

    [SerializeField]
    List<GameObject> party;

    void Start()
    {
        foreach (GameObject gameObj in party)
        {
            gameObj.AddComponent<DoAfterSupporter>().SetAction = ReduceParty;
        }

        partyCounter = party.Count;
    }

    void ReduceParty()
    {
        partyCounter--;
        if (partyCounter <= 0)
        {
            DoAfter();
        }
    }

    void DoAfter()
    {
        Destroy(gameObject);
    }
}
