using UnityEngine;
using UnityEngine.Events;
using Zenject;

[RequireComponent(typeof(AttackIndicator), typeof(SwordsmanAnimation), typeof(SwordsmanPositioning))]
public abstract class Swordsman : MonoBehaviour
{
    [SerializeField] private HealthView _healthView;

    [HideInInspector] public UnityEvent OnDefeated = new();

    protected bool CanFight = false;

    private SwordsmanConfig _config;

    private SwordsmanHealth _health;
    private SwordsmanAnimation _animation;
    private SwordsmanPositioning _positioning;
    private AttackIndicator _attackIndicator;
    private SwordsmanStateHandler _stateHandler;

    private GameplayCamera _camera;

    [Inject]
    private void Construct(GameplayCamera camera)
    {
        _camera = camera;
    }

    private void Awake()
    {
        _animation = GetComponent<SwordsmanAnimation>();
        _positioning = GetComponent<SwordsmanPositioning>();
        _attackIndicator = GetComponent<AttackIndicator>();
    }

    protected void Init(SwordsmanConfig config, int positionIndex)
    {
        _config = config;

        _animation.Init(_config.AnimationConfig);
        _positioning.Init(positionIndex);
        _attackIndicator.Deactivate();

        _health = new SwordsmanHealth(_healthView, _config.FeaturesConfig.HealthAmount);
        _stateHandler = new SwordsmanStateHandler(this);

        _positioning.OnDroppedOutOfArena.AddListener(Defeat);
    }

    public bool IsAttacking { get; protected set; }
    public bool IsParrying { get; protected set; }

    public SwordsmanConfig Config => _config;
    public SwordsmanAnimation Animation => _animation;
    public SwordsmanPositioning Positioning => _positioning;
    public AttackIndicator AttackIndicator => _attackIndicator;
    public SwordsmanStateHandler StateHandler => _stateHandler;

    public void AllowFight() => CanFight = true;
    public void ForbidFight() => CanFight = false;

    public abstract void PerformAttack();

    public void TakeHit()
    {
        if (_stateHandler.IsParrying)
            ParryHit();
        else
            TakeDamage();
    }

    private void ParryHit()
    {
        _positioning.MoveBackward();
    }

    private void TakeDamage()
    {
        _camera.Shake(Vector2.down);

        _animation.SetDamage();
        int healthAmount = _health.Reduce();

        if (healthAmount == 0)
            Defeat();
    }

    private void Defeat()
    {
        _stateHandler.SetDefeatState();
        OnDefeated.Invoke();
    }
}
