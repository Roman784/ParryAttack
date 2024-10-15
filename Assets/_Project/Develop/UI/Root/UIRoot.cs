using System.Collections;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    [SerializeField] private Transform _uiSceneContainer;
    [SerializeField] private LoadingScreen _loadingScreen;

    private void Awake()
    {
        HideLoadingScreen();
    }

    public Coroutine ShowLoadingScreen()
    {
        return Coroutines.StartRoutine(_loadingScreen.Show());
    }

    public Coroutine HideLoadingScreen()
    {
        return Coroutines.StartRoutine(_loadingScreen.Hide());
    }

    public void AttachSceneUI(Transform sceneUI)
    {
        ClearSceneUI();

        sceneUI.SetParent(_uiSceneContainer, false);

        RectTransform rectTransform = sceneUI.GetComponent<RectTransform>();
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }

    private void ClearSceneUI()
    {
        int childCount = _uiSceneContainer.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(_uiSceneContainer.GetChild(i).gameObject);
        }
    }
}
