using Zenject;

public class UISounds
{
    private UISoundsConfig _config;
    private AudioPlayer _audioPlayer;

    public UISounds(AudioPlayer audioPlayer, UISoundsConfig config)
    {
        _audioPlayer = audioPlayer;
        _config = config;
    }

    public void PlayButtonClick()
    {
        _audioPlayer.Play(_config._buttonClick);
    }
}
