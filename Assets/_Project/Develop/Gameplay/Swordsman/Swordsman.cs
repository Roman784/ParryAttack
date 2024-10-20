using UnityEngine;
using UnityEngine.Events;
using Zenject;

[RequireComponent(typeof(AttackIndicator), typeof(SwordsmanAnimation), typeof(SwordsmanPositioning))]
[RequireComponent(typeof(SwordsmanSound))]
public abstract class Swordsman : MonoBehaviour
{
    [SerializeField] private HealthView _healthView;

    [HideInInspector] public UnityEvent OnDefeated = new();

    protected bool CanFight = false;

    private SwordsmanConfig _config;

    private SwordsmanHealth _health;
    private SwordsmanAnimation _animation;
    private SwordsmanPositioning _positioning;
    private SwordsmanSound _sound;
    private AttackIndicator _attackIndicator;
    private SwordsmanStateHandler _stateHandler;

    private GameplayCamera _camera;
    private AudioPlayer _audioPlayer;

    [Inject]
    private void Construct(GameplayCamera camera, AudioPlayer audioPlayer)
    {
        _camera = camera;
        _audioPlayer = audioPlayer;
    }

    private void Awake()
    {
        _animation = GetComponent<SwordsmanAnimation>();
        _positioning = GetComponent<SwordsmanPositioning>();
        _sound = GetComponent<SwordsmanSound>();
        _attackIndicator = GetComponent<AttackIndicator>();
    }

    protected void Init(SwordsmanConfig config, int positionIndex)
    {
        _config = config;

        _animation.Init(_config.AnimationConfig, _config.SpritesConfig);
        _positioning.Init(positionIndex);
        _sound.Init(_audioPlayer);
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
    public SwordsmanSound Sound => _sound;
    public AttackIndicator AttackIndicator => _attackIndicator;
    public SwordsmanStateHandler StateHandler => _stateHandler;

    public void AllowFight() => CanFight = true;
    public void ForbidFight()
    {
        IsAttacking = false;
        IsParrying = false;
        CanFight = false;
    }

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
        _sound.PlayParrySound();
    }

    private void TakeDamage()
    {
        _camera.Shake(Vector2.down);

        _animation.SetDamage();
        _sound.PlayDamageSound();

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
