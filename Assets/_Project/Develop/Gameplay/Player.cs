using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private SwordsmanConfig _config;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private SwordsmanStateHandler _stateHandler;
    private IInput _input;

    [Inject]
    private void Construct(IInput input)
    {
        _input = input;
    }

    private void Start()
    {
        _stateHandler = new SwordsmanStateHandler();

        _stateHandler.SetIdleState();
    }

    private void Update()
    {
        _stateHandler.Update(_input);
    }

    public void SetIdleSprite()
    {
        _spriteRenderer.sprite = _config.Idle;
    }

    public void SetPreattackSprite()
    {
        _spriteRenderer.sprite = _config.Preattack;
    }

    public void SetAttackSprite()
    {
        _spriteRenderer.sprite = _config.Attack;
    }

    public void SetParrySprite()
    {
        _spriteRenderer.sprite = _config.Parry;
    }
}
