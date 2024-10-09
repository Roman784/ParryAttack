using UnityEngine;
using UnityEngine.Events;
using Zenject;

[RequireComponent(typeof(SwordsmanHealth), typeof(SwordsmanAnimation), typeof(SwordsmanPositioning))]
[RequireComponent(typeof(AttackIndicator))]
public abstract class Swordsman : MonoBehaviour
{
    public UnityEvent OnDefeated = new();

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
        _health = GetComponent<SwordsmanHealth>();
        _animation = GetComponent<SwordsmanAnimation>();
        _positioning = GetComponent<SwordsmanPositioning>();
        _attackIndicator = GetComponent<AttackIndicator>();
    }

    protected void Init(SwordsmanConfig config)
    {
        _config = config;

        _health.Init(_config.FeaturesConfig.HeartsCount);
        _animation.Init(_config.AnimationConfig);
        _positioning.Init();
        _attackIndicator.Deactivate();

        _stateHandler = new SwordsmanStateHandler(this);

        _positioning.OnMovedBack.AddListener(() =>
        {
            if (!_positioning.InArena())
                Defeat();
        });
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
        _positioning.MoveBack();
    }

    private void TakeDamage()
    {
        _camera.Shake(Vector2.down);

        _animation.SetDamage();
        int fullHeartsCount = _health.SpendHeart();

        if (fullHeartsCount == 0)
            Defeat();
    }

    private void Defeat()
    {
        _stateHandler.SetDefeatState();
        OnDefeated.Invoke();
    }
}
