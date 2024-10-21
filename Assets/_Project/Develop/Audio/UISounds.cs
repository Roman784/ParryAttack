using Zenject;

public class UISounds
{
    private AudioConfig _config;
    private AudioPlayer _audioPlayer;

    public UISounds(AudioPlayer audioPlayer, AudioConfig config)
    {
        _audioPlayer = audioPlayer;
        _config = config;
    }

    public void PlayButtonClick()
    {
        _audioPlayer.Play(_config.ButtonClickSound);
    }
}
