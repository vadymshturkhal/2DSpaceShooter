using UnityEngine;
using UnityEngine.InputSystem;

public class GameAudioSource : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1f)]
    float levelVolume = 0.5f;

    [SerializeField]
    [Range(0, 1f)]
    float pauseSoundVolume = 0.5f;

    [SerializeField]
    AudioClipName pauseSound;

    [SerializeField]
    AudioClipName levelSound;

    void Awake()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        AudioManager.Initialize(audioSource);
    }

    void Start()
    {
        PlayLevelMusic();
    }

    public void PauseSound(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AudioManager.Play(pauseSound, pauseSoundVolume);
        }
    }

    void PlayLevelMusic()
    {
        AudioManager.PlayLevel(levelSound, levelVolume);
    }
}
