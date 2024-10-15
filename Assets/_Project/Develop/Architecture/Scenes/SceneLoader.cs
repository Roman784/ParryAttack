using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader
{
    private UIRoot _uiRoot;

    [Inject]
    private void Construct(UIRoot uIRoot)
    {
        _uiRoot = uIRoot;
    }

    public void LoadGameplay()
    {
        Coroutines.StopAllRoutines();
        Coroutines.StartRoutine(
            LoadScene<GameplayEntryPoint>(Scenes.GAMEPLAY));
    }

    public void LoadLevelList()
    {
        Coroutines.StopAllRoutines();
        Coroutines.StartRoutine(
            LoadScene<LevelListEntryPoint>(Scenes.LEVEL_LIST));
    }

    public void LoadThemeSelection()
    {
        Coroutines.StopAllRoutines();
        Coroutines.StartRoutine(
            LoadScene<ThemeSelectionEntryPoint>(Scenes.THEME_SELECTION));
    }

    private IEnumerator LoadScene<T>(string sceneName) where T : EntryPoint
    {
        yield return _uiRoot.ShowLoadingScreen();

        yield return SceneManager.LoadSceneAsync(sceneName);

        EntryPoint sceneEntryPoint = Object.FindFirstObjectByType<T>();
        yield return sceneEntryPoint.Run();

        yield return _uiRoot.HideLoadingScreen();
    }
}
