using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwordsmanAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private SwordsmanAnimationConfig _config;
    private SwordsmanSpritesConfig _spritesConfig;

    private Coroutine _tickingDamage;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Init(SwordsmanAnimationConfig config, SwordsmanSpritesConfig spritesConfig)
    {
        _config = config;
        _spritesConfig = spritesConfig;
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
        Coroutines.StopRoutine(_tickingDamage);
        _tickingDamage = Coroutines.StartRoutine(TickingDamage());
    }

    public void SetDefeat()
    {
        _spriteRenderer.sprite = _spritesConfig.Defeat;
        _animator.SetTrigger("Defeat");
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
