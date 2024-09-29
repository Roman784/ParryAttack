using UnityEngine;

public class SwordsmanAnimation
{
    private SwordsmanConfig _config;
    private SpriteRenderer _spriteRenderer;

    public SwordsmanAnimation(SwordsmanConfig config, SpriteRenderer spriteRenderer)
    {
        _config = config;
        _spriteRenderer = spriteRenderer;
    }

    public void SetIdle()
    {
        _spriteRenderer.sprite = _config.Idle;
    }

    public void SetPreattack()
    {
        _spriteRenderer.sprite = _config.Preattack;
    }

    public void SetAttack()
    {
        _spriteRenderer.sprite = _config.Attack;
    }

    public void SetParry()
    {
        _spriteRenderer.sprite = _config.Parry;
    }
}
