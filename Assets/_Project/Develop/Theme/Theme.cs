using UnityEngine;

public class Theme : MonoBehaviour
{
    public void Init(ThemeData data)
    {
        Data = data;
    }

    public ThemeData Data { get; private set; }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
