using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    private static BackgroundAudio instance;

    [SerializeField] private AudioSource audioSource; // Reference to the AudioSource component

    private void Awake()
    {
        // Ensure only one instance of BackgroundAudio exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persist across scenes
        }
    }

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Get the AudioSource if not assigned
        }

        if (!audioSource.isPlaying)
        {
            audioSource.loop = true; // Ensure the audio loops
            audioSource.Play(); // Start playing the audio
        }
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(volume); // Adjust the volume (0.0 to 1.0)
        }
    }

    public void StopAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void PlayAudio()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
