using UnityEngine;

public class LevelListMenu
{
    private LevelListUI _ui;
    private LevelListConfig _config;
    private SceneLoader _sceneLoader;
    private LevelTracker _levelTracker;
    private Storage _storage;
    private AudioPlayer _audioPlayer;
    private Translator _translator;

    public LevelListMenu(LevelListUI ui, LevelListConfig config, SceneLoader sceneLoader, LevelTracker levelTracker, 
                         Storage storage, AudioPlayer audioPlayer, Translator translator)
    {
        _ui = ui;
        _config = config;
        _sceneLoader = sceneLoader;
        _levelTracker = levelTracker;
        _storage = storage;
        _audioPlayer = audioPlayer;
        _translator = translator;
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
        int number = levelData.Number;
        string enemyName = _translator.GetEnemyName(levelData.EnemyData.Name);
        Sprite enemyProfile = levelData.EnemyData.SpritesConfig.Profile;

        button.Init(this, number, enemyName, enemyProfile);

        bool isLock = number > _storage.GameData.LastCompletedLevel + 1;

        if (isLock)
            button.Lock();
        else
            button.Unlock();
    }
}
