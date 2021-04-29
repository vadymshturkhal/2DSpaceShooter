using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        audioSource = source;

        if (audioClips.Count != 0)
        {
            return;
        }

        audioClips.Add(AudioClipName.EnemyDefaultFire,
            Resources.Load<AudioClip>("Audio/EnemyFire"));
        audioClips.Add(AudioClipName.EnemyExplode,
            Resources.Load<AudioClip>("Audio/EnemyExplode"));
        audioClips.Add(AudioClipName.EnemyHit,
            Resources.Load<AudioClip>("Audio/EnemyHit"));
        audioClips.Add(AudioClipName.PlayerDefaultFire, 
            Resources.Load<AudioClip>("Audio/PlayerFire"));
        audioClips.Add(AudioClipName.PlayerExplode,
            Resources.Load<AudioClip>("Audio/PlayerExplode"));
        audioClips.Add(AudioClipName.PlayerHit,
            Resources.Load<AudioClip>("Audio/PlayerHit"));
        audioClips.Add(AudioClipName.PauseSound,
            Resources.Load<AudioClip>("Audio/PauseMenu"));
        audioClips.Add(AudioClipName.Level1Music,
            Resources.Load<AudioClip>("Audio/Level1"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
