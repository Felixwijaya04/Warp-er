using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip bgm;
    public AudioClip walk;
    public AudioClip jump;
    public AudioClip lever1;
    public AudioClip lever2;
    public AudioClip doorOpen;
    public AudioClip grabPacket;
    public AudioClip ladder;

    private void Start()
    {
        musicSource.clip = bgm;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
