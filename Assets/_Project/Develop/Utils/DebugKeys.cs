using UnityEngine;
using Zenject;

public class DebugKeys : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                _sceneLoader.LoadGameplay();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                _sceneLoader.LoadLevelList();
            }
        }
    }
}
