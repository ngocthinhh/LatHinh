using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [Header("Audio Source")]
    public AudioSource BackgroundSource;
    public AudioSource ClickSource;
    public AudioSource InGameNoticationSource;
    public AudioSource ResultNoticationSource;

    [Header("Sound Assets")] 
    public AudioClip ClickSound;
    public AudioClip WinSound;
    public AudioClip LoseSound;
    public AudioClip SuccesSound;
    public AudioClip FallSound;
    public AudioClip BackgroundSound;

    public void PlaySound(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void StopSound(AudioSource source)
    {
        source.Stop();
    }

    public void PauseSound(AudioSource source)
    {
        source.Pause();
    }

    public void ContinueSound(AudioSource source)
    {
        source.Play();
    }
}
