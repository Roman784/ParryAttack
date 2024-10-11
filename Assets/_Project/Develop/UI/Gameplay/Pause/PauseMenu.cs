using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _levelListButton;
    [SerializeField] private Button _themeButton;

    [Space]

    [SerializeField] private GameObject _panel;

    private bool _isPaused;

    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _isPaused = false;
        _panel.SetActive(false);

        _pauseButton.onClick.AddListener(Pause);
        _levelListButton.onClick.AddListener(OpenLevelListScene);
        _themeButton.onClick.AddListener(OpenThemeSelectionScene);
    }

    public void Init(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
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
        _sceneLoader.LoadLevelList();
    }

    public void OpenThemeSelectionScene()
    {

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
}
