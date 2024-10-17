using UnityEngine;

public class EducationMenu
{
    private EducationView _view;

    public EducationMenu(EducationView view)
    {
        _view = view;

        _view.OnCLoseButtonClick.AddListener(Hide);
    }

    public void Show()
    {
        Object.FindObjectOfType<LoadingScreen>().HideInstantly();

        _view.Show();
        Time.timeScale = 0f;
    }

    public void Hide()
    {
        Time.timeScale = 1f;
        _view.Hide();
    }
}
