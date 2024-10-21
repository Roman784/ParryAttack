using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourcer : MonoBehaviour
{
    private AudioPlayer _player;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public AudioSourcer Init(AudioPlayer player)
    {
        _player = player;
        _player.OnVolumeChanged.AddListener(ChangeVolume);

        _source.volume = _player.Volume;

        return this;
    }

    public void PlayOneShot(AudioClip clip)
    {
        _source.PlayOneShot(clip);

        DontDestroyOnLoad(gameObject);
        Invoke(nameof(Destroy), clip.length);
    }

    public void PlayLoop(AudioClip clip)
    {
        _source.clip = clip;
        _source.loop = true;
        _source.Play();

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeClip(AudioClip clip)
    {
        _source.clip = clip;
    }

    private void ChangeVolume(float volume)
    {
        _source.volume = volume;
    }

    private void Destroy()
    {
        _player.OnVolumeChanged.RemoveListener(ChangeVolume);
        Destroy(gameObject);
    }
}
