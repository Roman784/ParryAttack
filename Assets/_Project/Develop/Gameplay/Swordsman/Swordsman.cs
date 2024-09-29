using UnityEngine;

public class Swordsman : MonoBehaviour
{
    [SerializeField] private SwordsmanConfig _config;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    protected IInput Input;

    private SwordsmanStateHandler _stateHandler;
    private SwordsmanAnimation _animation;

    protected void Awake()
    {
        _animation = new SwordsmanAnimation(_config, _spriteRenderer);
        _stateHandler = new SwordsmanStateHandler(this);

        _stateHandler.SetIdleState();
    }

    protected void Update()
    {
        if (Input != null)
            _stateHandler.Update(Input);
    }

    public SwordsmanAnimation Animation => _animation;
}
