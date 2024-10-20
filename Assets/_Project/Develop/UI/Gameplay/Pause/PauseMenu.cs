using UnityEngine;
using UnityEngine.UI;
using Zenject.SpaceFighter;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _levelListButton;
    [SerializeField] private Button _themeButton;
    [SerializeField] private Button _audioButton;

    [Space]

    [SerializeField] private GameObject _panel;

    [Space]

    [SerializeField] private Image _soundIconView;
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private bool _isPaused;

    private SceneLoader _sceneLoader;
    private AudioPlayer _audioPlayer;

    private void Awake()
    {
        _isPaused = false;
        _panel.SetActive(false);

        _pauseButton.onClick.AddListener(Pause);
        _levelListButton.onClick.AddListener(OpenLevelListScene);
        _themeButton.onClick.AddListener(OpenThemeSelectionScene);
        _audioButton.onClick.AddListener(ChangeAudioVolume);
    }

    public void Init(SceneLoader sceneLoader, AudioPlayer audioPlayer)
    {
        _sceneLoader = sceneLoader;
        _audioPlayer = audioPlayer;

        UpdateAudioIconView(_audioPlayer.Volume);
    }

    public void Pause()
    {
        if (!_isPaused)
            StopGame();
        else
            ContinueGame();

        _panel.SetActive(_isPaused);
    }

    public void OpenLevelListScene()
    {
        ContinueGame();
        _sceneLoader.LoadLevelList();
    }

    public void OpenThemeSelectionScene()
    {
        ContinueGame();
        _sceneLoader.LoadThemeSelection();
    }

    public void ChangeAudioVolume()
    {
        float newVolume = _audioPlayer.ChangeVolume();
        UpdateAudioIconView(newVolume);
    }

    private void StopGame()
    {
        _isPaused = true;
        Time.timeScale = 0f;
    }

    private void ContinueGame()
    {
        _isPaused = false;
        Time.timeScale = 1f;
    }

    private void UpdateAudioIconView(float volume)
    {
        _soundIconView.sprite = volume > 0 ? _soundOn : _soundOff;
    }
}
