using UnityEngine;

[RequireComponent (typeof(SwordsmanHealth), typeof(SwordsmanAnimation), typeof(AttackIndicator))]
public abstract class Swordsman : MonoBehaviour
{
    private SwordsmanConfig _config;

    private SwordsmanHealth _health;
    private SwordsmanAnimation _animation;
    private AttackIndicator _attackIndicator;

    private SwordsmanStateHandler _stateHandler;

    protected void Init(SwordsmanConfig config)
    {
        _config = config;

        _health = GetComponent<SwordsmanHealth>();
        _health.Init(_config.FeaturesConfig.HeartsCount);

        _animation = GetComponent<SwordsmanAnimation>();
        _animation.Init(_config.AnimationConfig);

        _attackIndicator = GetComponent<AttackIndicator>();
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
    public AttackIndicator AttackIndicator => _attackIndicator;
    public SwordsmanStateHandler StateHandler => _stateHandler;

    public abstract void PerformAttack();
    public void TakeDamage()
    {
        if (StateHandler.IsParrying) return;

        Animation.SetDamage();
        _health.SpendHeart();
    }
}
