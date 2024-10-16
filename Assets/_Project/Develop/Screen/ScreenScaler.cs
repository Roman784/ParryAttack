using UnityEngine;

public class ScreenScaler : MonoBehaviour
{
    [SerializeField] private float _zoom;
    [SerializeField] private float _minSize;
    [SerializeField] private float _maxSize;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void FixedUpdate()
    {
        Scale();
    }

    private void Scale()
    {
        float screenRatio = (float)Screen.height / (float)Screen.width;
        float targetOrthographicSize = screenRatio * _zoom;

        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, _minSize, _maxSize);

        _camera.orthographicSize = targetOrthographicSize;
    }
}
