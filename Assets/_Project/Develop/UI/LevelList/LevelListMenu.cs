using UnityEngine;

public class LevelListMenu
{
    private LevelListUI _ui;
    private LevelListConfig _config;
    private SceneLoader _sceneLoader;
    private LevelTracker _levelTracker;
    private Storage _storage;
    private AudioPlayer _audioPlayer;

    public LevelListMenu(LevelListUI ui, LevelListConfig config, SceneLoader sceneLoader, LevelTracker levelTracker, 
                         Storage storage, AudioPlayer audioPlayer)
    {
        _ui = ui;
        _config = config;
        _sceneLoader = sceneLoader;
        _levelTracker = levelTracker;
        _storage = storage;
        _audioPlayer = audioPlayer;
    }

    public void OpenLevel(int number)
    {
        _audioPlayer.UISounds.PlayButtonClick();
        _levelTracker.SetCurrentLevelNumber(number);
        OpenGameplayScene();
    }

    public void OpenGameplayScene()
    {
        _sceneLoader.LoadGameplay();
    }

    public void CreateButtons()
    {
        int count = _config.Levels.Count;

        for (int i = 0; i < count; i++)
        {
            var button = _ui.CreateButton();
            InitButton(button, _config.Levels[i]);
        }
    }

    private void InitButton(LevelSelectionButton button, LevelData levelData)
    {
        Debug.Log($"number: {levelData.Number}");
        Debug.Log($"last completed: {_storage.GameData.LastCompletedLevel + 1}");
        int number = levelData.Number;
        string enemyName = levelData.EnemyData.Name;
        Sprite enemyProfile = levelData.EnemyData.SpritesConfig.Profile;

        button.Init(this, number, enemyName, enemyProfile);

        bool isLock = number > _storage.GameData.LastCompletedLevel + 1;

        if (isLock)
            button.Lock();
        else
            button.Unlock();
    }
}
