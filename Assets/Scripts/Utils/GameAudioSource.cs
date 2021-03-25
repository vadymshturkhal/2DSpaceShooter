using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioSource : MonoBehaviour
{
    void Awake()
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        AudioManager.Initialize(source);
    }
}
