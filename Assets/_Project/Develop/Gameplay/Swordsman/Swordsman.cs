using UnityEngine;

public class Swordsman : MonoBehaviour
{
    [SerializeField] private SwordsmanConfig _config;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Space]

    [SerializeField] private AttackIndicator _attackIndicator;

    protected IInput Input;

    private SwordsmanStateHandler _stateHandler;
    private SwordsmanAnimation _animation;

    protected void Awake()
    {
        _animation = new SwordsmanAnimation(_config.SpritesConfig, _spriteRenderer);
        _stateHandler = new SwordsmanStateHandler(this);

        _stateHandler.SetIdleState();
    }

    protected void Update()
    {
        if (Input != null)
            _stateHandler.Update(Input);
    }

    public SwordsmanConfig Config => _config;
    public SwordsmanAnimation Animation => _animation;
    public AttackIndicator AttackIndicator => _attackIndicator;
}
