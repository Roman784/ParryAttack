using UnityEngine;

public class LevelListMenu
{
    private LevelListUI _ui;
    private LevelListConfig _config;

    public LevelListMenu(LevelListUI ui, LevelListConfig config)
    {
        _ui = ui;
        _config = config;
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

        button.Init(number, enemyName, enemyProfile);
    }
}
