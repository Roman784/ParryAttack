using UnityEngine;

public class LevelListMenu
{
    private LevelListUI _ui;
    private LevelListConfig _config;
    private SceneLoader _sceneLoader;
    private LevelTracker _levelTracker;

    public LevelListMenu(LevelListUI ui, LevelListConfig config, SceneLoader sceneLoader, LevelTracker levelTracker)
    {
        _ui = ui;
        _config = config;
        _sceneLoader = sceneLoader;
        _levelTracker = levelTracker;
    }

    public void OpenLevel(int number)
    {
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
        string enemyName = levelData.EnemyName;
        Sprite enemyProfile = levelData.EnemySprites.Profile;

        button.Init(this, number, enemyName, enemyProfile);
    }
}
