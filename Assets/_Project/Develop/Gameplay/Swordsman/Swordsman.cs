using UnityEngine;

public class Swordsman : MonoBehaviour
{
    [SerializeField] private SwordsmanConfig _config;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Space]

    [SerializeField] private AttackIndicator _attackIndicator;

    protected SwordsmanStateHandler StateHandler;
    private SwordsmanAnimation _animation;

    protected void Awake()
    {
        _animation = new SwordsmanAnimation(_config.SpritesConfig, _spriteRenderer);
        StateHandler = new SwordsmanStateHandler(this);

        StateHandler.SetIdleState();
    }

    public bool IsAttacking { get; protected set; }
    public bool IsParrying { get; protected set; }

    public SwordsmanConfig Config => _config;
    public SwordsmanAnimation Animation => _animation;
    public AttackIndicator AttackIndicator => _attackIndicator;
}
