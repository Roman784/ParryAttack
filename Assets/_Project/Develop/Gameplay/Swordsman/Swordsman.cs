using UnityEngine;
using Zenject;

[RequireComponent(typeof(SwordsmanHealth), typeof(SwordsmanAnimation), typeof(SwordsmanPositioning))]
[RequireComponent(typeof(AttackIndicator))]
public abstract class Swordsman : MonoBehaviour
{
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

        _health.OnAllHeartsSpent.AddListener(() => 
        {
            Debug.Log("Death");
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

    public abstract void PerformAttack();

    public void TakeHit()
    {
        if (StateHandler.IsParrying)
            ParryHit();
        else
            TakeDamage();
    }

    private void ParryHit()
    {
        Positioning.MoveBack();
    }

    private void TakeDamage()
    {
        _camera.Shaker.ShakeWeakly(Vector2.down);

        Animation.SetDamage();
        _health.SpendHeart();
    }
}
