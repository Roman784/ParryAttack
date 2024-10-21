using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class AudioPlayer
{
    public UnityEvent<float> OnVolumeChanged = new UnityEvent<float>();

    private AudioSourcer _sourcerPrefab;
    private float _volume;

    private AudioConfig _config;
    private UISounds _uiSounds;
    private BackgroundMusic _backgroundMusic;

    private Storage _storage;

    [Inject]
    private void Construct(AudioSourcer sourcerPrefab, AudioConfig config, Storage storage)
    {
        _config = config;
        _sourcerPrefab = sourcerPrefab;
        _storage = storage;
    }

    public void Init(float volume)
    {
        _volume = volume;

        _uiSounds = new UISounds(this, _config);
        _backgroundMusic = new BackgroundMusic(this, _config);
    }

    public float Volume => _volume;
    public UISounds UISounds => _uiSounds;
    public BackgroundMusic BackgroundMusic => _backgroundMusic;

    public AudioSourcer Play(AudioClip clip)
    {
        AudioSourcer sourcer = CreateSourcer();
        sourcer.PlayOneShot(clip);

        return sourcer;
    }

    public AudioSourcer CreateSourcer()
    {
        AudioSourcer sourcer = GameObject.Instantiate(_sourcerPrefab).Init(this);
        return sourcer;
    }

    public float ChangeVolume()
    {
        _volume = _volume > 0f ? 0f : 1f;
        OnVolumeChanged?.Invoke(_volume);

        _storage.SetAudioVolume(_volume);

        return _volume;
    }
}
