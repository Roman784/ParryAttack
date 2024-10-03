using System.Collections;
using UnityEngine;

public class SwordsmanAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private SwordsmanAnimationConfig _config;
    private SwordsmanSpritesConfig _spritesConfig;

    private Coroutine _tickingDamageCoroutine;

    public void Init(SwordsmanAnimationConfig config)
    {
        _config = config;
        _spritesConfig = config.SpritesConfig;
    }

    public void SetIdle()
    {
        _spriteRenderer.sprite = _spritesConfig.Idle;
    }

    public void SetPreattack()
    {
        _spriteRenderer.sprite = _spritesConfig.Preattack;
    }

    public void SetAttack()
    {
        _spriteRenderer.sprite = _spritesConfig.Attack;
    }

    public void SetParry()
    {
        _spriteRenderer.sprite = _spritesConfig.Parry;
    }

    public void SetDamage()
    {
        if (_tickingDamageCoroutine != null)
            Coroutines.StopRoutine(_tickingDamageCoroutine);

        Coroutines.StartRoutine(TickingDamage());
    }

    private IEnumerator TickingDamage()
    {
        Color initialColor = _spriteRenderer.color;
        Color damageColor = _config.DamageColor;

        for (int i = 0; i < _config.DamageTickCount; i++)
        {
            if (i % 2 == 0) _spriteRenderer.color = damageColor;
            else _spriteRenderer.color = initialColor;

            yield return new WaitForSeconds(_config.DamageTickRate);
        }

        _spriteRenderer.color = initialColor;
    }
}
