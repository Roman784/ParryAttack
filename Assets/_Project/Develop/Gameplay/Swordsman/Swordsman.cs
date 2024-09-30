using UnityEngine;

public class Swordsman : MonoBehaviour
{
    [SerializeField] private SwordsmanConfig _config;

    [Space]

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private AttackIndicator _attackIndicator;

    private SwordsmanStateHandler _stateHandler;
    private SwordsmanAnimation _animation;

    protected void Awake()
    {
        _animation = new SwordsmanAnimation(_config.AnimationConfig, _spriteRenderer);
        _stateHandler = new SwordsmanStateHandler(this);

        _stateHandler.SetIdleState();
    }

    public bool IsAttacking { get; protected set; }
    public bool IsParrying { get; protected set; }

    public SwordsmanConfig Config => _config;
    public SwordsmanStateHandler StateHandler => _stateHandler;
    public SwordsmanAnimation Animation => _animation;
    public AttackIndicator AttackIndicator => _attackIndicator;
}
