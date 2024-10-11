using UnityEngine;

public class UIRoot : MonoBehaviour
{
    [SerializeField] private Transform _uiSceneContainer;
    [SerializeField] private GameObject _loadingScreen;

    private void Awake()
    {
        HideLoadingScreen();
    }

    public void HideLoadingScreen()
    {
        _loadingScreen.SetActive(false);
    }

    public void ShowLoadingScreen()
    {
        _loadingScreen.SetActive(true);
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
