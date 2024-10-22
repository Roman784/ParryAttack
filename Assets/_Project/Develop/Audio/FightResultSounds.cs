using UnityEngine;

public class FightResultSounds
{
    private AudioConfig _config;
    private AudioPlayer _audioPlayer;

    public FightResultSounds(AudioPlayer audioPlayer, AudioConfig config)
    {
        _audioPlayer = audioPlayer;
        _config = config;
    }

    public void PlayVictory()
    {
        _audioPlayer.Play(_config.VictorySound);
    }

    public void PlayLosing()
    {
        _audioPlayer.Play(_config.LosingSound);
    }
}
