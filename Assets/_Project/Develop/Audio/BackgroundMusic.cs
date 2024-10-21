using System.Collections;
using UnityEngine;

public class BackgroundMusic
{
    private AudioPlayer _audioPlayer;
    private AudioConfig _config;

    private AudioSourcer _sourcer;

    public BackgroundMusic(AudioPlayer audioPlayer, AudioConfig config)
    {
        _audioPlayer = audioPlayer;
        _config = config;
    }

    public void Start()
    {
        _sourcer = _audioPlayer.CreateSourcer();
        _sourcer.name = "[BACKGROUND_MUSIC_SOURCER]";

        Play();
    }

    private void Play()
    {
        AudioClip clip = GetRandomClip();
        _sourcer.PlayLoop(clip);

        Coroutines.StartRoutine(Repeat(clip.length));
    }

    private IEnumerator Repeat(float delay)
    {
        yield return new WaitForSeconds(delay);

        Play();
    }

    private AudioClip GetRandomClip() => _config.BackgroundMusic[Random.Range(0, _config.BackgroundMusic.Length)];
}
